using System; // เพิ่มตัวนี้
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlots = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();

    // Event สำหรับแจ้งเตือน UI เมื่อมีการเปลี่ยนแปลงไอเทม
    public Action onInventoryChanged;

    [SerializeField] private ItemData meleeItem;
    // ... (โค้ดเดิมของคุณใน Awake และ Start) ...

    public bool AddItem(ItemData item, int amount = 1)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.amount += amount;
                onInventoryChanged?.Invoke(); // แจ้ง UI
                return true;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.amount = amount;
                onInventoryChanged?.Invoke(); // แจ้ง UI
                return true;
            }
        }
        return false;
    }

    // อย่าลืมใส่ onInventoryChanged?.Invoke(); ใน RemoveItem ด้วยนะครับ
}