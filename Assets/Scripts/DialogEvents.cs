namespace DefaultNamespace
{
    /// <summary>
    ///  對話開始事件
    /// </summary>
    public interface DialogStartEvent
    {
        void OnDialogStarted();
    }

    /// <summary>
    /// 對話結束事件
    /// </summary>
    public interface DialogEndEvent
    {
        void OnDialogEnded();
    }
}