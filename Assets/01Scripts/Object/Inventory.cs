using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EquipResult
{
    Success,
    Remove,
    Fail,
}

public class Inventory
{
    public List<Item> itemList;
    public Dictionary<EquipmentType, Equipment> equipmentList;

    public Inventory()
    {
        Initialize();
    }

    // #1 인벤토리를 초기화하는 과정에서 할당을 안해주고 EquipItem() 실행 시 키 값이 없다고 오류가 나오는데
    // 그래서 저는 EquipItem()에 따로 예외를 두어서 매번 추가할지 검사하기보다는 몰아서해놓자라는 마음으로 작성하였습니다.
    public void Initialize()
    {
        itemList = new List<Item>(24);
        equipmentList = new Dictionary<EquipmentType, Equipment>() { };
        for (int i = 0; i < Enum.GetValues(typeof(EquipmentType)).Length; i++)
        {
            equipmentList.Add((EquipmentType)i, null);
        }
    }

    public EquipResult EquipItem(int index)
    {
        if (itemList[index] is not Equipment target)
            return EquipResult.Fail;

        EquipmentType targetType = target.equipmentType;

        if (equipmentList[targetType] == target)
        {
            UnequipItem(targetType);
            return EquipResult.Remove;
        }

        if (targetType == EquipmentType.LeftHand || targetType == EquipmentType.RightHand)
        {
            UnequipItem(EquipmentType.TwoHands);
        }
        else if (targetType == EquipmentType.TwoHands)
        {
            UnequipItem(EquipmentType.LeftHand);
            UnequipItem(EquipmentType.RightHand);
        }

        if (equipmentList[targetType] != null)
        {
            equipmentList[targetType].isEquiped = false;
        }
        equipmentList[targetType] = target;
        target.isEquiped = true;
        return EquipResult.Success;
    }

    private void UnequipItem(EquipmentType partType)
    {
        if (equipmentList[partType] == null)
            return;

        equipmentList[partType].isEquiped = false;
        equipmentList[partType] = null;
    }

    public void DestoryItem(int index)
    {
        Item target = itemList[index];
        if ((int)target.itemType < 100)
        {
            EquipmentType type = ((Equipment)target).equipmentType;
            if (equipmentList[type] == target)
            {
                UnequipItem(type);
            }
        }

        itemList.RemoveAt(index);
    }
}
