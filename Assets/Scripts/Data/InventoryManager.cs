using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ต้องมีอันนี้เพื่อจัดการรูปภาพ

public class InventoryManager : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public Image[] uiSlots; // ลากช่อง Image ในกระเป๋ามาใส่ในนี้ให้ครบ

    public void AddItem(ItemData data)
    {
        items.Add(data);
        Debug.Log("เพิ่มของแล้ว!");

        RefreshUI(); // ทุกครั้งที่เพิ่มของ ให้สั่งวาดรูปใหม่
    }

    void RefreshUI()
    {
        // วนลูปเช็คตามจำนวนของที่มีใน List
        for (int i = 0; i < items.Count; i++)
        {
            if (i < uiSlots.Length) // ป้องกันของเกินจำนวนช่องที่มี
            {
                uiSlots[i].sprite = items[i].icon; // เอารูปจาก ItemData มาใส่ใน UI
                uiSlots[i].enabled = true; // เปิดการแสดงผลรูป
            }
        }
    }
}