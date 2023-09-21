using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager I;

    [SerializeField] private EquipmentSO equipmentSO;

    private void Awake()
    {
        I = this;
    }

    private Item GetEquipmentData(ItemType type)
    {
        Equipment newItem = new Equipment();
        newItem.itemType = type;
        if (type == ItemType.Empty)
            return newItem;

        EquipmentData tempData = equipmentSO.itemData[(int)type];
        newItem.equipmentType = tempData.equipmentType;
        newItem.itemSprite = tempData.itemSprite;
        newItem.itemName = tempData.itemName;
        newItem.desc = tempData.desc;
        newItem.gold = tempData.gold;
        newItem.atk = tempData.atk;
        newItem.def = tempData.def;
        newItem.maxHp = tempData.maxHp;
        newItem.criticalChance = tempData.criticalChance;

        return newItem;
    }

    public void AddItem(List<Item> inven, ItemType type)
    {
        Item newItem = GetEquipmentData(type);
        inven.Add(newItem);
    }
}
