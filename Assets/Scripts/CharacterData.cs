using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData" , menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    /// <summary>
    /// 移動速度
    /// </summary>
    // [Range(0,20)]
    [Min(0)]
    public float moveSpeed = 3f;
}