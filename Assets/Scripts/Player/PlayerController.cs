using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : Character
{
    private PlayerMovement movement;
    private MeleeWeapon meleeWeapon; // อ้างอิงถึงอาวุธ

    protected override void Awake()
    {
        base.Awake();
        movement = GetComponent<PlayerMovement>();
        
        // หา MeleeWeapon ที่อยู่ในลูกของ Player
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }

    // ตัวอย่างใน PlayerMovement หรือ PlayerController
  void Update()
{
    // เช็คว่าอาวุธกำลังพุ่งอยู่หรือไม่
    bool isDashing = (meleeWeapon != null && meleeWeapon.IsDashing);

    if (isDashing)
    {
        // ถ้าพุ่งอยู่ "ห้าม" รับ Input เดิน และสั่งหยุดความเร็วเดินเดิม
        movement.StopVelocity(); 
        return; // จบการทำงานของ Update เฟรมนี้ตรงนี้เลย (ไม่ไปทำ HandleInput)
    }

    // ถ้าไม่ได้พุ่ง ถึงจะเดินได้ปกติ
    movement.HandleInput();
    movement.Animate();    
}

  
}