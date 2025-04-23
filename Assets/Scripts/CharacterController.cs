using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // deltaTime = 1/fps , 1/60 = 0.16667f
        var movement = Vector3.right * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}