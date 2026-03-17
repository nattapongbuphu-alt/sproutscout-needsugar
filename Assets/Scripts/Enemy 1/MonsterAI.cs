using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float attackRange = 1.5f; 

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player == null || isAttacking) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            
            StartAttack();
        }
        else if (distanceToPlayer < detectionRange)
        {
            
            MoveTowardsPlayer();
        }
        else
        {
            
            StopMoving();
        }
    }

    void MoveTowardsPlayer()
    {
        float direction = (player.position.x > transform.position.x) ? 1 : -1;
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        
        anim.SetFloat("speed", Mathf.Abs(direction));

        if (direction > 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
    }

    void StopMoving()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        anim.SetFloat("speed", 0); //  Idle
    }

    void StartAttack()
    {
        isAttacking = true;
        rb.linearVelocity = Vector2.zero;
        anim.SetFloat("speed", 0);
        anim.SetTrigger("attack"); 
    }

    
    public void FinishAttack()
    {
        isAttacking = false;
    }
}