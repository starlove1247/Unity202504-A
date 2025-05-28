using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [SerializeField]
    private PlayerInput playerInput;

   

    private void Start()
    {
        // 預設關閉對話視窗
        dialog.gameObject.SetActive(false);
        npcUI_Panel.alpha                                    =  0; // 預設設定UI透明度為0
        playerInput.actions.FindAction("Interact").performed += OnInteractActionPerformed;
    }

    private void OnDisable()
    {
        var interactAction = playerInput.actions.FindAction("Interact");
        interactAction.performed -= OnInteractActionPerformed;
    }

    /// <summary>
    ///  按下互動鍵
    /// </summary>
    /// <param name="obj"></param>
    private void OnInteractActionPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log($"NPC 互動鍵按下");
        if (characterInTrigger)
        {
            StartDialog();
        }
    }

    [Button("開始對話")]
    public void StartDialog()
    {
        dialog.gameObject.SetActive(true);
        dialog.SetTexts(dialogData.dialogTexts);
        dialog.StartDialog();
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

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        dialog.PlayNextDialog();
    }

    /// <summary>
    /// 紀錄角色在偵測範圍內
    /// </summary>
    private bool characterInTrigger;
    private void OnTriggerEnter2D(Collider2D col)
    {
        // 如果是角色才執行以下行為
        // if (col.gameObject.GetComponent<CharacterController>() != null)
        if (col.gameObject.TryGetComponent(out CharacterController character))
        {
            characterInTrigger = true;
            ShowNPCDialogHintUI();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // 如果是角色才執行以下行為
        if (col.gameObject.TryGetComponent(out CharacterController character))
        {
            characterInTrigger = false;
            CloseNPCDialogHintUI();
        }
    }
}