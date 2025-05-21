using NaughtyAttributes;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

    [SerializeField]
    private Dialog dialog;

    /// <summary>
    /// 紀錄目前播放到第幾段話(index) 從0開始
    /// </summary>
    private int dialogIndex = 0;

    [Button("播放第一段對話")]
    public void PlayFirstDialog()
    {
        // 如果沒有任何對話，不做任何事情
        if (dialogData.dialogTexts.Count == 0) return;
        dialogIndex = 0; // 重置Index
        dialog.SetText(dialogData.dialogTexts[dialogIndex]);
        dialog.PlayWriter();
    }

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        // 如果沒有任何對話，不做任何事情
        if (dialogData.dialogTexts.Count == 0) return;
        // 如果沒有下一段對話資料，就不做任何事情
        if (dialogIndex + 1 == dialogData.dialogTexts.Count) return;
        dialogIndex++;
        dialog.SetText(dialogData.dialogTexts[dialogIndex]);
        dialog.PlayWriter();
    }
}