using UnityEngine;
using TMPro; // ต้องเพิ่มตัวนี้เพื่อใช้งาน TextMeshPro

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    private float currentSpeed;

    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText; // ลาก Text ตัวเลขมาใส่ช่องนี้

    [Header("Components")]
    public Animator animator;
    public SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // ฟังก์ชันแยกสำหรับอัปเดตตัวเลขบนหน้าจอ
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth + " / " + maxHealth;
        }
    }

    public void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if (input.x > 0) sr.flipX = false;
        else if (input.x < 0) sr.flipX = true;

        if (input != Vector2.zero)
        {
            lastMoveDirection = input;
        }
    }

    void FixedUpdate()
    {
        currentSpeed = input.magnitude * moveSpeed;
        rb.linearVelocity = input * moveSpeed;
    }

    public void Animate()
    {
        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);
        animator.SetFloat("Speed", currentSpeed);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ป้องกันเลือดติดลบ

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player ตายแล้ว!");
        // ใส่คำสั่งเปลี่ยน Scene ไปหน้า Ending หรือ Game Over ที่นี่
    }
}