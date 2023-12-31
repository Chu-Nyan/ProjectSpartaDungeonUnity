using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public EquipmentSO equipmentSO;
    public EquipmentType equipmentType;
    public float atk;
    public float def;
    public float maxHp;
    public bool isEquiped = false;
    [Range(0f, 1f)] public float criticalChance;
}

public class Consumable : Item { }

public class Item
{
    public ItemType itemType;
    public Sprite itemSprite;
    public string itemName;
    public string desc;
    public int gold;
}