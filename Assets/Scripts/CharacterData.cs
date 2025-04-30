using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData" , menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    /// <summary>
    /// 移動速度
    /// </summary>
    public float moveSpeed = 3f;
}