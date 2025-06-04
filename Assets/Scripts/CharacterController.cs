using System;
using DefaultNamespace;
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
    private  bool        dead;

    private void Start()
    {
        //　遊戲開始，設定角色可以移動
        canMove        = true;
        moveAction     = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interact");
    }

    void Update()
    {
        // 死掉不能移動
        if (dead) return;
        // 角色不能用按鍵移動時，就不能移動
        if (canMove == false) return;
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

    /// <summary>
    /// 可不可用按鍵去讓角色移動的狀態
    /// </summary>
    private bool canMove ;
    public void SetCanMoving(bool canMove)
    {
        this.canMove = canMove;
    }
}