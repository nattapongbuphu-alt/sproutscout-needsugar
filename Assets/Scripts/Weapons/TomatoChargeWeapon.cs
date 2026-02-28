using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoChargeWeapon : Weapon
{
    [SerializeField] private GameObject tomatoPrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float maxChargeTime = 2f;
    [SerializeField] private float minForce = 3f;
    [SerializeField] private float maxForce = 15f;

    private float chargeTime;
    private bool isCharging;

    public override void StartUse()
    {
        isCharging = true;
        chargeTime = 0f;
    }

    public override void ReleaseUse()
    {
        if (!isCharging) return;

        isCharging = false;

        float percent = chargeTime / maxChargeTime;
        float force = Mathf.Lerp(minForce, maxForce, percent);

        GameObject tomato = Instantiate(
            tomatoPrefab,
            throwPoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = tomato.GetComponent<Rigidbody2D>();

        Vector2 mouse = Mouse.current.position.ReadValue();
        Vector2 world = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 dir = (world - (Vector2)throwPoint.position).normalized;

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    public override void Tick()
    {
        if (isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }
    }
}