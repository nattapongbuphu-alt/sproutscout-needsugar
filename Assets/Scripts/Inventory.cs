using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlots = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();

    void Awake()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    public bool AddItem(ItemData item, int amount = 1)
    {
        // หา slot ที่มี item เดิม
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.amount += amount;
                return true;
            }
        }

        // หา slot ว่าง
        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.amount = amount;
                return true;
            }
        }

        return false; // กระเป๋าเต็ม
    }

    public void RemoveItem(ItemData item, int amount = 1)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.amount -= amount;

                if (slot.amount <= 0)
                {
                    slot.item = null;
                    slot.amount = 0;
                }

                return;
            }
        }
    }
}