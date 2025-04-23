using UnityEngine;

public class CharacterController : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 水平的輸入 左右   -1 ~ 1
        var horizontal = Input.GetAxisRaw("Horizontal");
        // 垂直的輸入 上下 -1 ~ 1
        var vertical = Input.GetAxisRaw("Vertical");
        // 移動方向
        var direction = new Vector3(horizontal , vertical , 0); // 1,1,0
        direction = direction.normalized; // 正規化後 避免斜著走特別快的問題，最大為0.71f, 0.71f,0
        // 移動向量 deltaTime = 1/fps , 1/60 = 0.16667f
        var movement = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}