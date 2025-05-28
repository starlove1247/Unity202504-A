using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

    [SerializeField]
    private Dialog dialog;

    /// <summary>
    /// NPC UI物件
    /// </summary>
    [SerializeField]
    private CanvasGroup npcUI_Panel;

    private void Start()
    {
        // 預設關閉對話視窗
        dialog.gameObject.SetActive(false);
        npcUI_Panel.alpha = 0; // 預設設定UI透明度為0
    }
    [Button("顯示NPC對話提示UI")]
    private void ShowNPCDialogHintUI()
    {
        npcUI_Panel.DOFade(1 , 0.5f);
    }
    [Button("關閉NPC對話提示UI")]
    private void CloseNPCDialogHintUI()
    {
        npcUI_Panel.DOFade(0 , 0.5f);
    }
    [Button("開始對話")]
    public void StartDialog()
    {
        dialog.SetTexts(dialogData.dialogTexts);
        dialog.StartDialog();
    }

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        dialog.PlayNextDialog();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        ShowNPCDialogHintUI();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CloseNPCDialogHintUI();
    }
}