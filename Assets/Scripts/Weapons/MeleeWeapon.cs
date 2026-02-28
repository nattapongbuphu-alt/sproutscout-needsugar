using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float attackRate = 1f;
    [SerializeField] private float range = 1.5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private LayerMask enemyLayer;

    private float timer;

    public override void Tick()
    {
        timer += Time.deltaTime;

        if (timer >= attackRate)
        {
            timer = 0f;
            AttackNearestEnemy();
        }
    }

    void AttackNearestEnemy()
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
            {
                target.TakeDamage(damage);
                break; // µÕµÑÇáÃ¡¾Í
            }
        }
    }
}
