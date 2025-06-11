using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 對話事件處理器
    /// </summary>
    public class DialogEventHandler : DialogStartEvent , DialogEndEvent
    {
        public void OnDialogStarted()
        {
            Debug.Log($"OnDialogStarted");
            // 對話開始，角色無法移動
            CharacterController.Instance.SetCanMoving(false);
        }

        public void OnDialogEnded()
        {
            Debug.Log($"OnDialogEnded");
            // 對話結束，角色才可以移動
            CharacterController.Instance.SetCanMoving(true);
        }
    }
}