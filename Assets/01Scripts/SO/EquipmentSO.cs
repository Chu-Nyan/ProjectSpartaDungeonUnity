using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    SteelSword, WoodBow,
    WoodShiled,
    Empty = 999
}

public enum EquipmentType
{
    LeftHand, RightHand, TwoHands,
    Head, Top, Bottom, Shoes
}

[CreateAssetMenu(fileName = "Equipment", menuName = "SO/Item/Equipment", order = 1)]
public class EquipmentSO : ScriptableObject
{
    public EquipmentData[] itemData;
}

[Serializable]
public struct EquipmentData
{
    public ItemType itemType;
    public EquipmentType equipmentType;
    public Sprite itemSprite;
    public string itemName;
    public string desc;
    public int gold;
    public float atk;
    public float def;
    public float maxHp;
    [Range(0f, 1f)] public float criticalChance;
}