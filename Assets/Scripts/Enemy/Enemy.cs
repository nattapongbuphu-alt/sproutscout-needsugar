using static UnityEngine.GraphicsBuffer;

public class Enemy : Character
{
    private EnemyMovement movement;
    private EnemyAttack attack;

    protected override void Awake()
    {
        base.Awake();
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        //// สั่งให้เดินถ้าไม่อยู่ในระยะโจมตี
        //if (!attack.IsInRange(target))
        //{
        //    movement.MoveTowards(target);
        //}
        //else
        //{
        //    movement.Stop();
        //    attack.TryAttack(target);
        //}
    }
}