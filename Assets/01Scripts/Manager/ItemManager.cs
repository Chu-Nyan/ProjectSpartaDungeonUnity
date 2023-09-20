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

    private Item GetNewEquipmentData(ItemType type)
    {
        Equipment newItem = new Equipment();
        EquipmentData tempData = equipmentSO.itemData[(int)type];
        newItem.type = tempData.itemType;
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
        Item newItem = GetNewEquipmentData(type);
        inven.Add(newItem);
        UIManager.I.UpdatePlayerInvenUI();
    }

}
