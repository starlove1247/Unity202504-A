using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_DialogData", menuName = "Scriptable Objects/NPC_DialogData")]
public class NPC_DialogData : ScriptableObject
{
    public List<string> dialogTexts;
}
