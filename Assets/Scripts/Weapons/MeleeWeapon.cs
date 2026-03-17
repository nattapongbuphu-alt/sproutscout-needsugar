using UnityEngine;
using System.Collections;
using System.Collections.Generic; // ต้องมีตัวนี้เพื่อใช้ List

public class MeleeWeapon : Weapon
{
    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private int damage = 10;

    [Header("Dash Settings")]
    [SerializeField] private float dashForce = 25f;
    [SerializeField] private float dashDuration = 0.15f;

    private float timer;
    private Rigidbody2D playerRb;
    private bool isDashing = false;
    private Collider2D attackCollider;

    // รายชื่อศัตรูที่โดนโจมตีไปแล้วในการพุ่งครั้งนี้
    private List<IDamageable> hitTargets = new List<IDamageable>();

    void Awake()
    {
        playerRb = GetComponentInParent<Rigidbody2D>();
        attackCollider = GetComponent<Collider2D>();
        
        if (attackCollider != null) attackCollider.enabled = false;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= attackCooldown && !isDashing)
        {
            timer = 0f;
            StartCoroutine(DashAttackRoutine());
        }
    }

    IEnumerator DashAttackRoutine()
    {
        isDashing = true;
        hitTargets.Clear(); // ล้างรายชื่อศัตรูที่เคยโดนแทงในการพุ่งครั้งก่อน

        // 1. หาความเร็วและทิศทางไปหาเมาส์
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 dashDirection = (mousePos - playerRb.transform.position).normalized;

        // 2. เปิด Collider เตรียมตรวจจับ
        if (attackCollider != null) attackCollider.enabled = true;

        // 3. สั่งพุ่ง
        if (playerRb != null)
        {
            playerRb.linearVelocity = dashDirection * dashForce;
        }

        // 4. ระยะเวลาที่พุ่ง
        yield return new WaitForSeconds(dashDuration);
        
        // 5. หยุดและปิดการตรวจจับ
        if (playerRb != null) playerRb.linearVelocity = Vector2.zero;
        if (attackCollider != null) attackCollider.enabled = false;

        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDashing)
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            
            // ตรวจเช็คว่า:
            // 1. เป็นศัตรูที่รับดาเมจได้ไหม
            // 2. ศัตรูตัวนี้ "ยังไม่เคยโดนแทง" ในการพุ่งรอบนี้ใช่ไหม
            if (target != null && !hitTargets.Contains(target))
            {
                target.TakeDamage(damage); // ทำดาเมจ
                hitTargets.Add(target);    // เพิ่มชื่อลงใน List ว่าโดนไปแล้วนะ
                
                Debug.Log("แทงโดน: " + collision.name);
            }
        }
    }
}