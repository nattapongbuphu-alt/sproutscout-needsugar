using UnityEngine;
using UnityEngine.InputSystem;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject tomatoPrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float maxChargeTime = 2f;
    [SerializeField] private float minForce = 3f;
    [SerializeField] private float maxForce = 15f;

    [SerializeField] private LineRenderer line;
    [SerializeField] private int linePoints = 30;
    [SerializeField] private float timeBetweenPoints = 0.1f;

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

        line.positionCount = 0;
    }

    public override void Tick()
    {
        if (isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);

            float percent = chargeTime / maxChargeTime;
            float force = Mathf.Lerp(minForce, maxForce, percent);

            DrawTrajectory(force);
        }
    }

    void DrawTrajectory(float force)
    {
        line.positionCount = linePoints;

        Vector2 startPos = throwPoint.position;

        Vector2 mouse = Mouse.current.position.ReadValue();
        Vector2 world = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 dir = (world - startPos).normalized;

        Vector2 startVelocity = dir * force;

        for (int i = 0; i < linePoints; i++)
        {
            float t = i * timeBetweenPoints;

            Vector2 point = startPos + startVelocity * t +
                            0.5f * Physics2D.gravity * t * t;

            line.SetPosition(i, point);
        }
    }


}
