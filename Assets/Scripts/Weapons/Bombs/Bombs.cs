using UnityEngine;

public class Bombs : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    [SerializeField] private float radius = 3f;
    [SerializeField] private int damage = 40;
    [SerializeField] private LayerMask enemyLayer;

    void Start()
    {
        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            radius,
            enemyLayer
        );

        foreach (var hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}