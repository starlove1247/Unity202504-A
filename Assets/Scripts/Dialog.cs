using System;
using System.Collections.Generic;
using DefaultNamespace;
using NaughtyAttributes;
using Scripts.Custom;
using TMPEffects.Components;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
#region Public Variables

    public static Dialog Instance;

#endregion

#region Private Variables

    /// <summary>
    /// 所有的對話
    /// </summary>
    private List<string> dialogTexts;

    /// <summary>
    /// 紀錄目前播放到第幾段話(index) 從0開始
    /// </summary>
    private int dialogIndex = 0;

    /// <summary>
    /// 是否在對話中的狀態
    /// </summary>
    private bool isInDialog;

    [SerializeField]
    private TMPWriter tmpWriter;

    [SerializeField]
    private PlayerInput playerInput;

    /// <summary>
    /// 下一句的提示圖片
    /// </summary>
    [SerializeField]
    private Image nextDialogHint;

    // [SerializeField]
    // private CharacterController characterController;

#endregion

#region Unity events

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextDialogHint.gameObject.SetActive(false);
        tmpWriter.OnFinishWriter.AddListener(OnFinishWriter);
        tmpWriter.OnStartWriter.AddListener(OnStartWriter);
    }

#endregion

#region Public Methods

    /// <summary>
    /// 回傳 - 是否在對話中的狀態
    /// </summary>
    /// <returns></returns>
    public bool IsInDialog()
    {
        return isInDialog;
    }

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        // 如果沒有任何對話，不做任何事情
        if (dialogTexts.Count == 0)
        {
            Debug.LogError("錯誤，因為沒有對話資料!");
            return;
        }

        // 如果沒有下一段對話資料，就不做任何事情 = 播放完畢
        if (dialogIndex + 1 == dialogTexts.Count) return;
        dialogIndex++;
        SetText(dialogTexts[dialogIndex]);
        PlayWriter();
    }

    [Button("執行打字機效果")]
    public void PlayWriter()
    {
        tmpWriter.RestartWriter();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position + new Vector3(0 , 2 , 0);
    }

    public void SetText(string dialogText)
    {
        tmpWriter.SetText(dialogText);
    }

    public void SetTexts(List<string> texts)
    {
        dialogTexts = texts;
    }

    [Button("跳過打字機效果，直接播放整行")]
    public void SkipWriter()
    {
        tmpWriter.SkipWriter();
    }

    public void StartDialog()
    {
        // 如果沒有任何對話，不做任何事情
        if (dialogTexts.Count == 0) return;
        isInDialog  = true;
        dialogIndex = 0; // 重置Index
        SetText(dialogTexts[dialogIndex]);
        PlayWriter();
        // 對話開始，設定角色不能移[按鍵移動]
        // characterController.SetCanMoving(false);
        EventBus.Raise<DialogStartEvent>(_ => _.OnDialogStarted());
    }

#endregion

#region Private Methods

    [Button("關閉對話框")]
    private void CloseDialog()
    {
        gameObject.SetActive(false);
    }

    private void InteractActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log($"對話系統 互動鍵按下");
        // 如果對話完畢(最後一段話)，而且打字機效果結束，則關閉對話框
        if (dialogIndex + 1 == dialogTexts.Count && tmpWriter.IsWriting == false)
        {
            isInDialog = false;
            // 對話結束，讓角色可以移動
            // characterController.SetCanMoving(true);
            EventBus.Raise<DialogEndEvent>(_ => _.OnDialogEnded());
            CloseDialog();
            return;
        }

        // 如果還在播放打字機效果，則Skip打字機效果
        if (tmpWriter.IsWriting) SkipWriter();
        // 如果打字機效果結束，則播放下一段文字
        else if (tmpWriter.IsWriting == false) PlayNextDialog();
    }

    private void OnDisable()
    {
        var interactAction = playerInput.actions.FindAction("Interact");
        interactAction.performed -= InteractActionOnperformed;
    }

    private void OnEnable()
    {
        var interactAction = playerInput.actions.FindAction("Interact");
        interactAction.performed += InteractActionOnperformed;
    }

    private void OnFinishWriter(TMPWriter arg0)
    {
        // 如果播放完，顯示下一句提示圖片
        nextDialogHint.gameObject.SetActive(true);
    }

    private void OnStartWriter(TMPWriter arg0)
    {
        // 如果打字機效果開始，隱藏提示圖片
        nextDialogHint.gameObject.SetActive(false);
    }

#endregion
}