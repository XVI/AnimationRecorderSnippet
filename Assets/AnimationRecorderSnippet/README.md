# AnimationRecorderSnippet
実行時にアニメーションを記録するためのサンプルプロジェクトです。
本プロジェクトを参考に、モーションキャプチャやVR HMDなどで操作したキャラクターなどのアニメーションを記録するプログラムを
作成していただくことを目的として公開しています。

サンプルとして、マウスに追従する青い球の動きを記録し、再生できるシーンを用意しました。

# 動作確認済み環境
- Unity 2019.2.4f1
- Windows 10 64bit

だいたいUnity5.4くらいのAPIを使用していますので、Unity2018.4LTSなど、Unity2019.2より古いバージョンでも動くはずです。

# サンプルシーンの操作方法
1. Assets/AnimationRecorderSnippet/Scenes/MousePositionRecorderExample.unityを開く
2. エディタ上で実行
3. マウスを動かして、青い球がマウスポインタに追従することを確認
4. Start Recordingボタンをクリック
5. 適当にマウスを動かす
6. Stop Recordingボタンをクリック
7. Play Animationボタンをクリック
8. 手順5 で動かしたとおりに青い球が動くことを確認
9. Stop Animationボタンをクリック
10. 再び青い球がマウスポインタに追従することを確認

# ライセンス
The MIT Licenseです。同封のLICENSEファイルを参照してください。
（本プロジェクトを参考にして新規に組み上げたのであれば、とくに表記は必要ありません）
