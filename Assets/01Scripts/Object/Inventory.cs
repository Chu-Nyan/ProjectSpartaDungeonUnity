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

    // #1 �κ��丮�� �ʱ�ȭ�ϴ� �������� �Ҵ��� �����ְ� EquipItem() ���� �� Ű ���� ���ٰ� ������ �����µ�
    // �׷��� ���� EquipItem()�� ���� ���ܸ� �ξ �Ź� �߰����� �˻��ϱ⺸�ٴ� ���Ƽ��س��ڶ�� �������� �ۼ��Ͽ����ϴ�.
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
