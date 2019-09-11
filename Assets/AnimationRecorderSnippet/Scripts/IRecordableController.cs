// アニメーションを記録する対象を操作するものであることをラベル付けするためのインターフェース
public interface IRecordableController
{
    // Updateを停止できるようにしておく
    // 同時にMonoBehaviourを継承することを前提とする
    bool enabled { get; set; }
}
