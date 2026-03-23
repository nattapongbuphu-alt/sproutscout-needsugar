using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public SpriteRenderer enemySprite;

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // หันหน้าซ้าย-ขวา
        if (direction.x > 0) enemySprite.flipX = false;
        else if (direction.x < 0) enemySprite.flipX = true;
    }

    public void Stop()
    {
        // ถ้าใช้ Rigidbody2D สามารถสั่ง rb.linearVelocity = Vector2.zero ตรงนี้ได้
    }
}