using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 記録したアニメーションを再生するためのコンポーネント
[RequireComponent(typeof(Animation))]
public class AnimationPlayer : MonoBehaviour
{
    public AnimationClip clip;
    new Animation animation;
    const string AnimationName = "Recorded Animation";
    IRecordableController[] controllers;

    // uGUIのボタン押下から呼ばれる
    public void PlayAnimation()
    {
        if (clip == null) return;

        animation.Stop();
        if (animation.GetClipCount() > 0)
        {
            animation.RemoveClip(AnimationName);
        }
        animation.AddClip(clip, AnimationName);
        animation.Play(AnimationName);

        // MouseTransformControllerがアニメーション処理の後に実行されて、アニメーションが上書きされてしまう可能性を排除する
        // また、再生中はマウス追従処理を停止しておいたほうが、アニメーションを再生中であることがわかりやすい
        foreach (var controller in controllers)
        {
            controller.enabled = false;
        }
    }

    public void StopAnimation()
    {
        foreach (var controller in controllers)
        {
            controller.enabled = true;
        }

        animation.Stop();
    }

    void Start()
    {
        animation = GetComponent<Animation>();
        controllers = GetComponents<IRecordableController>();
    }
}
