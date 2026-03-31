using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Weapon currentWeapon;
    private Inventory inventory;

    [SerializeField] private ItemData meleeItem;
    [SerializeField] private ItemData rangedItem;

    public Transform spawnPoint;

    void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    void Start()
    {
        meleeItem = Resources.Load<ItemData>("Items/WeaponTest 1");
        rangedItem = Resources.Load<ItemData>("Items/WeaponTest");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipFromInventory(meleeItem);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipFromInventory(rangedItem);
        }

        if (currentWeapon == null) return;

        if (Input.GetMouseButtonDown(0))
            currentWeapon.StartUse();

        if (Input.GetMouseButtonUp(0))
            currentWeapon.ReleaseUse();

        currentWeapon.Tick();
    }

    public void EquipFromInventory(ItemData item)
    {
        if (item == null) return;
        if (currentWeapon != null)
            Destroy(currentWeapon.gameObject);

        GameObject weaponObj = Instantiate(item.weaponPrefab, spawnPoint);
        currentWeapon = weaponObj.GetComponent<Weapon>();
    }

    public void UseCurrentWeapon(ItemData item)
    {
        if (currentWeapon == null) return;

        currentWeapon.StartUse();

       
        //inventory.RemoveItem(item, 1);
    }


}