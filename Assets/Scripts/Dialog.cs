using NaughtyAttributes;
using TMPEffects.Components;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private TMPWriter tmpWriter;

    // [ContextMenu("執行打字機效果")]
    [Button("執行打字機效果")]
    // [ContextMenu(nameof(PlayWriter))]
    /// <summary>
    /// 執行打字機效果
    /// </summary>
    private void PlayWriter()
    {
        tmpWriter.RestartWriter();
    }

    /// <summary>
    /// 跳過打字機效果，直接播放整行
    /// </summary>
    // [ContextMenu("跳過打字機效果，直接播放整行")]
    [Button("跳過打字機效果，直接播放整行")]
    private void SkipWriter()
    {
        tmpWriter.SkipWriter();
    }
}