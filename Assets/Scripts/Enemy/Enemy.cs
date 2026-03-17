using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    [Header("Movement & Target")]
    public Transform target;           
    public float moveSpeed = 3f;

    [Header("Attack Settings")]
    public EnemyData data;             
    public Transform attackPoint;      
    public SpriteRenderer indicator;   // ใส่ IndicatorVisual (ลูกของ AttackPoint)

    [Header("Visuals")]
    public SpriteRenderer enemySprite; 

    private bool isAttacking = false;

    protected override void Awake()
    {
        base.Awake();
        if (indicator != null) indicator.enabled = false;
    }

    void Update()
    {
        if (target == null || data == null || attackPoint == null) return;

        float distance = Vector3.Distance(attackPoint.position, target.position);

        if (!isAttacking)
        {
            if (distance > data.attackRange)
            {
                MoveToTarget();
            }
            else
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }

    void MoveToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction.x > 0) enemySprite.flipX = false;
        else if (direction.x < 0) enemySprite.flipX = true;
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        // 1. จัดการ Indicator (วงกลมแจ้งเตือน)
        if (indicator != null)
        {
            // สูตรคำนวณสเกลให้เป๊ะตามภาพ Sprite จริง
            float spriteWidth = indicator.sprite.bounds.size.x;
            float targetDiameter = data.attackRange * 2f;
            float finalScale = targetDiameter / spriteWidth;
            
            indicator.transform.localScale = new Vector3(finalScale, finalScale, 1);
            indicator.enabled = true;

            float warningTime = 0.6f;
            float timer = 0f;
            while (timer < warningTime)
            {
                indicator.enabled = !indicator.enabled;
                yield return new WaitForSeconds(0.1f);
                timer += 0.1f;
            }
            indicator.enabled = false;
        }

        // 2. ส่วนการโจมตี (นำ TakeDamage กลับมา)
       if (target != null)
    {
        float distanceAtHit = Vector3.Distance(attackPoint.position, target.position);
        
        // ถ้าผู้เล่นเดินหนีออกไปเกินระยะ + เผื่อระยะให้นิดหน่อย (0.1f) จะไม่โดนดาเมจ
        if (distanceAtHit <= data.attackRange + 0.1f) 
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(data.damage);
            }
        }
    }

        // 3. คูลดาวน์
        yield return new WaitForSeconds(data.attackCooldown);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null && data != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(attackPoint.position, data.attackRange);
        }
    }
}