using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    public Animator animator;
    public SpriteRenderer sr;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (input.sqrMagnitude > 1) input.Normalize();

        if (input.x > 0) sr.flipX = false;
        else if (input.x < 0) sr.flipX = true;

        if (input != Vector2.zero) lastMoveDirection = input;
    }

    void FixedUpdate()
    {
        currentSpeed = input.magnitude * moveSpeed;
        rb.linearVelocity = input * moveSpeed;
    }

    public void Animate()
    {
        if (animator == null) return;
        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);
        animator.SetFloat("Speed", currentSpeed);
    }

    public void StopVelocity()
    {
        input = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
    }
}