using UnityEngine;

public class Character : MonoBehaviour , IDamageable
{
    [SerializeField] protected int maxHP = 100;
    protected int currentHP;

    protected virtual void Awake()
    {
        currentHP = maxHP;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
