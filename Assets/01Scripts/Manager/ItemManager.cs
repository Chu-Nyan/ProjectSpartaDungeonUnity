using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] private EquipmentSO equipmentSO;

    private void Awake()
    {
        Instance = this;
    }

    public Item GetNewEquipmentItem(ItemType type)
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


}
