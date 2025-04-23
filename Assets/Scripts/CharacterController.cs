using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction moveAction; // 移動行為
    private InputAction jumpAction; // 互動行為

    private void Start()
    {
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        // 互動事件 串接我們自己的方法
        jumpAction.performed += JumpActionOnperformed;
    }

    private void JumpActionOnperformed(InputAction.CallbackContext obj)
    {
        if (dead) return;
        Debug.Log($"jump");
    }

    private bool dead;

    void Update()
    {
        if (dead) return;
        if (jumpAction.WasPressedThisFrame())
        {
            Debug.Log($"jump pressed");
        }

        var moveVector2 = moveAction.ReadValue<Vector2>();
        // 水平的輸入 左右   -1 ~ 1
        // var horizontal = Input.GetAxisRaw("Horizontal");
        // 垂直的輸入 上下 -1 ~ 1
        // var vertical = Input.GetAxisRaw("Vertical");
        // 移動方向
        var direction = new Vector3(moveVector2.x , moveVector2.y , 0); // 1,1,0
        // direction = direction.normalized;                               // 正規化後 避免斜著走特別快的問題，最大為0.71f, 0.71f,0
        // 移動向量 deltaTime = 1/fps , 1/60 = 0.16667f
        var movement = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}