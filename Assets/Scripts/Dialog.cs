using NaughtyAttributes;
using TMPEffects.Components;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private TMPWriter tmpWriter;

    [SerializeField]
    private TMP_Text tmpText;
    
   [Button("執行打字機效果")]
    public void PlayWriter()
    {
        tmpWriter.RestartWriter();
    }

   [Button("跳過打字機效果，直接播放整行")]
    public void SkipWriter()
    {
        tmpWriter.SkipWriter();
    }

    public void SetText(string dialogText)
    {
        tmpText.SetText(dialogText);
    }
}