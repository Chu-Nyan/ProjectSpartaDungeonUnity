using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName = "";
    public int lv;
    public float maxExp;
    public float maxHp;
    public float hp;
    public float atk;
    public float def;
    public float criticalChance;
    protected int gold;

    public List<Item> inventory;
    public List<Equipment> unitEquipment;

    public virtual int Gold { get { return gold; } set { gold = value; } }

    protected virtual void Awake()
    {
        inventory = new List<Item>(24);
        unitEquipment = new List<Equipment>(Enum.GetValues(typeof(EquipmentType)).Length);
        unitEquipment[1] = new Equipment();
    }
}
