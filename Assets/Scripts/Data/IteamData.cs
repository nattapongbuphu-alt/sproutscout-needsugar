using UnityEngine;

public enum ItemType
{
    Crop,
    Weapon
}

[CreateAssetMenu(menuName = "Game/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public GameObject weaponPrefab; // ถ้าเป็นอาวุธ
}