using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float interactionRange = 1.5f;
    
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Vector2 moveInput;
    private Vector2 lastDirection = Vector2.down;
    private Rigidbody2D rb;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (animator == null)
            animator = GetComponent<Animator>();
        
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // ตั้ง default gravity เป็น 0
        if (rb != null)
            rb.gravityScale = 0f;
    }

    private void Update()
    {
        HandleInput();
        HandleAnimation();

        // Interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNearby();
        }
    }

    private void FixedUpdate()
    {
        // เคลื่อนที่ตัวละคร
        if (rb != null)
        {
            rb.velocity = moveInput * moveSpeed;
        }
    }

    private void HandleInput()
    {
        // รับ input จากผู้เล่น
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize เพื่อให้การเคลื่อนที่ diagonal ไม่เร็วขึ้น
        if (moveInput.magnitude > 0)
        {
            moveInput.Normalize();
            lastDirection = moveInput;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void HandleAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
            animator.SetBool("IsMoving", isMoving);
        }

        // Flip sprite ถ้าหันไปทางขวา
        if (spriteRenderer != null && lastDirection.x != 0)
        {
            spriteRenderer.flipX = lastDirection.x < 0;
        }
    }

    private void InteractWithNearby()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                return; // Interact กับแรกเจออย่างเดียว
            }
        }
    }

    // Debug visualization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

    public Vector2 GetLastDirection()
    {
        return lastDirection;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
