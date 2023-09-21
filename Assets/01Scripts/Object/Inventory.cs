using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> itemList;
    public Dictionary<EquipmentType, Equipment> equipmentList;

    public Inventory()
    {
        itemList = new List<Item>(24);
    }

    public void EquipItem(Item item)
    {

    }

    public void DestoryItem(int index)
    {
        Item taget = itemList[index];
        switch ((int)taget.itemType)
        {
            case  < 100:
                Debug.Log("장비아이템");
                break;
            default:
                break;
        }
        itemList.RemoveAt(index);
    }
}
