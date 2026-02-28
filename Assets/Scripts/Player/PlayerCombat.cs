using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Weapon currentWeapon;
    private Inventory inventory;

    private ItemData testItem;

    void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    void Start()
    {
        testItem = Resources.Load<ItemData>("Items/WeaponTest");
        if (testItem == null)
            Debug.LogError("โหลดไม่เจอ!");
        else
            Debug.Log("โหลดสำเร็จ: " + testItem.name);
    }

    void Update()
    {
        // กด 1 เพื่อใส่อาวุธ
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipFromInventory(testItem);
        }

        if (currentWeapon == null) return;

        // กดเมาส์ซ้ายเริ่มชาร์จ
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.StartUse();
        }

        // ปล่อยเมาส์ยิง
        if (Input.GetMouseButtonUp(0))
        {
            currentWeapon.ReleaseUse();
            
        }

        // อัปเดตการชาร์จทุกเฟรม
        currentWeapon.Tick();
    }

    public void EquipFromInventory(ItemData item)
    {
        if (item == null) return;
        if (item.itemType != ItemType.Weapon) return;

        // ลบของเก่า
        if (currentWeapon != null)
            Destroy(currentWeapon.gameObject);

        // สร้างอาวุธใหม่
        GameObject weaponObj = Instantiate(
            item.weaponPrefab,
            transform
        );

        currentWeapon = weaponObj.GetComponent<Weapon>();
    }

    public void UseCurrentWeapon(ItemData item)
    {
        if (currentWeapon == null) return;

        currentWeapon.StartUse();

        // ถ้าเป็นอาวุธแบบใช้แล้วหมด เช่น มะเขือเทศ
        inventory.RemoveItem(item, 1);
    }


}