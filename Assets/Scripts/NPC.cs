using NaughtyAttributes;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

    [SerializeField]
    private Dialog dialog;

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
}