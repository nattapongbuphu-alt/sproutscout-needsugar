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
}

