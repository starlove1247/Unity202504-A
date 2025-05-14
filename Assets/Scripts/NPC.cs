using NaughtyAttributes;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

    [SerializeField]
    private Dialog dialog;

    [Button("播放對話")]
    public void PlayDialog()
    {
        dialog.SetText(dialogData.dialogTexts[0]);
        dialog.PlayWriter();
    }
}