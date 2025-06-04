using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

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
        Dialog.Instance.gameObject.SetActive(false);
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
        // 如果已經在對話中，就不再開始對話
        if (Dialog.Instance.IsInDialog()) return;
        // 角色在範圍內，開始對話
        if (characterInTrigger)
        {
            StartDialog();
        }
    }

    [Button("開始對話")]
    public void StartDialog()
    {
        Dialog.Instance.SetPosition(transform.position);
        Dialog.Instance.gameObject.SetActive(true);
        Dialog.Instance.SetTexts(dialogData.dialogTexts);
        Dialog.Instance.StartDialog();
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
        Dialog.Instance.PlayNextDialog();
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