using UnityEngine;

public class Enemy : Character
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}