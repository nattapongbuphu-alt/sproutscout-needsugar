using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private int damage = 25;
    [SerializeField] private float range = 1.5f;
    [SerializeField] private LayerMask enemyLayer;

    protected override void Use()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            range,
            enemyLayer
        );

        foreach (var hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(damage);
        }
        
    }
}
