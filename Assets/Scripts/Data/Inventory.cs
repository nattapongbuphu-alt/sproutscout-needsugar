using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlots = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();


    [SerializeField] private ItemData meleeItem;
    [SerializeField] private ItemData rangedItem;

    void Awake()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    void Start()
    {
        meleeItem = Resources.Load<ItemData>("Items/WeaponTest 1");
        rangedItem = Resources.Load<ItemData>("Items/WeaponTest");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(meleeItem, 5);
            Debug.Log("Added 5 items");
        }
    }

    public bool AddItem(ItemData item, int amount = 1)
    {
        // �� slot ����� item ���
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.amount += amount;
                return true;
            }
        }

        // �� slot ��ҧ
        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.amount = amount;
                return true;
            }
        }

        return false; // ���������
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