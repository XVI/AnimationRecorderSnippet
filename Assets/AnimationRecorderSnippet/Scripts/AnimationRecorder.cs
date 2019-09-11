using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アニメーションを記録するためのコンポーネント
[RequireComponent(typeof(AnimationPlayer))]
public class AnimationRecorder : MonoBehaviour
{
    AnimationPlayer player;
    AnimationCurve[] curves;
    bool recording = false;
    float startTime;

    // uGUIのボタン押下から呼ばれる
    public void StartRecording()
    {
        curves = new AnimationCurve[3];
        for (var index = 0; index < curves.Length; index++)
        {
            curves[index] = new AnimationCurve();
        }

        startTime = Time.time;
        recording = true;
    }

    // uGUIのボタン押下から呼ばれる
    public void StopRecording()
    {
        var clip = new AnimationClip();

        // ここでAnimationClipをlegacyにしておかないと、SetCurveの呼び出しに失敗する
        clip.legacy = true;

        // 長いアニメーションを記録した場合は、SetCurveで時間がかかる
        clip.SetCurve("", typeof(Transform), "localPosition.x", curves[0]);
        clip.SetCurve("", typeof(Transform), "localPosition.y", curves[1]);
        clip.SetCurve("", typeof(Transform), "localPosition.z", curves[2]);

        player.clip = clip;
        recording = false;
    }

    void Start()
    {
        player = GetComponent<AnimationPlayer>();
    }

    // 今後、部分記録を実装する際にはアニメーション処理の後で記録する必要があるので、LateUpdateにしておく
    // Updateにする場合は、MouseTransformController.Update()の後になるように実行順を設定しておく必要がある
    void LateUpdate()
    {
        if (!recording) return;

        var time = Time.time - startTime;
        var localPosition = transform.localPosition;

        // AnimationCurve.AddKey(float,float)ではtangent = 0のためease-in, ease-outのカーブになる
        // 理想的にはLinearにしたほうがきれいにアニメーションするが、毎フレーム記録しているためほぼ気づかない
        curves[0].AddKey(time, localPosition.x);
        curves[1].AddKey(time, localPosition.y);
        curves[2].AddKey(time, localPosition.z);
    }
}
