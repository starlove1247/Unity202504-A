using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction moveAction;     // 移動行為
    private InputAction interactAction; // 互動行為
    private bool        dead;

    private void Start()
    {
        moveAction     = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interact");
    }

    void Update()
    {
        if (dead) return;
        if (interactAction.WasPressedThisFrame()) // 互動按鈕按下的判斷式
        {
            // Debug.Log($"interact button pressed");
        }

        var moveVector2 = moveAction.ReadValue<Vector2>();
        // 移動方向
        var direction = new Vector3(moveVector2.x , moveVector2.y , 0); // 1,1,0
        // 移動向量 deltaTime = 1/fps , 1/60 = 0.16667f
        var movement = direction * characterData.moveSpeed * Time.deltaTime;
        transform.position      += movement;
    }
}