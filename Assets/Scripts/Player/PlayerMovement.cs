using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //public void HandleInput()
    //{
    //  input.x = Input.GetAxisRaw("Horizontal");
    //  input.y = Input.GetAxisRaw("Vertical");
    //    input.Normalize();
    //}

   public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        input.Normalize();
    }




    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

}
