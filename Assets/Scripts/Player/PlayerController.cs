using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : Character
{
   private PlayerMovement movement;

    protected override void Awake()
    {
        base.Awake();

        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        movement.HandleInput();
    }

    public override void TakeDamage(int damage)
    {
        Shield shield = GetComponentInChildren<Shield>();

        if (shield != null && shield.IsActive())
            damage = Mathf.RoundToInt(damage * 0.3f);

        base.TakeDamage(damage);
    }
}

