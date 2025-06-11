using System.Reflection.Emit;
using DefaultNamespace;
using Scripts.Custom;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterPrefab;

    [SerializeField]
    private NPC npcPrefab;

    [SerializeField]
    private Dialog dialogPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 註冊對話事件處理器
        EventBus.Subscribe<DialogEventHandler>();
        // 產生角色、npc、對話
        Instantiate(characterPrefab);
        Instantiate(npcPrefab);
        Instantiate(dialogPrefab);
    }
}