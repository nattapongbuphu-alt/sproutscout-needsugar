using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f; // ความเร็วพุ่ง 
    private Rigidbody2D rb;                   // ตัวควบคุมฟิสิกส์
    private Vector2 startPos;                 // จุดเริ่มต้นที่ยิงออกไป
    private float targetDistance;             // ระยะทางที่ต้องวิ่งไปให้ถึง
    private bool isMoving = false;            // สถานะว่ากำลังเคลื่อนที่อยู่หรือไม่

    void Awake()
    {
        // เมื่อเริ่มสร้างมะเขือเทศ ให้ไปดึงคอมโพเนนต์ Rigidbody 2D มาเก็บไว้
        rb = GetComponent<Rigidbody2D>();
    }

    // ฟังก์ชันนี้เหมือน "ใบสั่งงาน" ที่ RangedWeapon ส่งมาให้
    public void Launch(Vector2 direction, float distance)
    {
        startPos = transform.position; // บันทึกว่าเริ่มพุ่งจากจุดไหน
        targetDistance = distance;     // บันทึกว่าต้องพุ่งไปไกลแค่ไหน
        isMoving = true;               // เปลี่ยนสถานะเป็นกำลังเคลื่อนที่

        if (rb != null)
        {
            // สั่งให้ Rigidbody พุ่งไปในทิศทาง (direction) ด้วยความเร็ว (speed)
            rb.linearVelocity = direction * speed;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // ทุกๆ เฟรม จะคอยวัดว่า "จากจุดเริ่ม วิ่งมาไกลแค่ไหนแล้ว?"
            float traveled = Vector2.Distance(startPos, transform.position);
            
            // ถ้าวิ่งมาจน "มากกว่าหรือเท่ากับ" ระยะที่เงาบอกไว้
            if (traveled >= targetDistance)
            {
                StopObject(); // สั่งให้หยุดทันที!
            }
        }
    }

    private void StopObject()
    {
        isMoving = false;     // เลิกเช็กระยะทาง
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;        // เซตความเร็วเป็น 0 (หยุดกึก)
            rb.bodyType = RigidbodyType2D.Kinematic; // เปลี่ยนเป็น Kinematic เพื่อไม่ให้ใครมาชนแล้วขยับได้
        }

        Invoke("DestroyObject", 2f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}