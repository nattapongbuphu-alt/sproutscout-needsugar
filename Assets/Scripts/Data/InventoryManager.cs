using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��ͧ���ѹ������ͨѴ����ٻ�Ҿ

public class InventoryManager : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public Image[] uiSlots; // �ҡ��ͧ Image 㹡����������㹹�����ú

    public void AddItem(ItemData data)
    {
        items.Add(data);
        Debug.Log("�����ͧ����!");

        RefreshUI(); // �ء���駷�������ͧ �������Ҵ�ٻ����
    }

    void RefreshUI()
    {
        // ǹ�ٻ�礵���ӹǹ�ͧ������ List
        for (int i = 0; i < items.Count; i++)
        {
            if (i < uiSlots.Length) // ��ͧ�ѹ�ͧ�Թ�ӹǹ��ͧ�����
            {
                uiSlots[i].sprite = items[i].icon; // ����ٻ�ҡ ItemData ������ UI
                uiSlots[i].enabled = true; // �Դ����ʴ����ٻ
            }
        }
    }
    public void DropItem (int slotIndex)
    {
        if (slotIndex < items.count)
        {
            itemDate dataTodrop = items[slotIndex];
            vector3 spawnPosition = transfrom.Position + transform.forward *2f;
            if (dataTodrop.weaponPrefap ! = null)
            {
                Instantiate(dataTodrop.weaponPrefap,spawnPosition,Quaternion.Identity);
                Debug.Log("วาง"+ dataTodrop.itemsname + "ลงบนพื้นแล้ว");
                //4 delete items on the list form inventory and Update UI

                items.RemoveAt (slotIndex);
                RefreshUI();
            }
        }
    }
    void RefreshUI ()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            if (i < items.count)
            {
                uiSlots[i].sprite = items[i].icon;
                uiSlots[i].enabled = true ; // = show item on inventory
            }
            else
            {
                uiSlots[i].sprite = null;
                uiSlots[i].enabled = false ; //but don't have item close photo in inventory or destroy photo
                 
            }
        }
    }

}