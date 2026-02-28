using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Weapon currentWeapon;
    private Inventory inventory;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
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