using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerSO stat;

    private float exp;

    public override int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            HUDManager.instance.updateGoldHUD();
        }
    }
    public float Exp
    {
        get { return exp; }
        set
        {
            exp = value;
            if (LevelUP())
                HUDManager.instance.updateAllHUD();
            else
                HUDManager.instance.updateLvExpHUD();
        }
    }

    protected override void Awake()
    {
        base.Awake();

        CallStatSO();
        inventory.Add(ItemManager.Instance.GetNewEquipmentItem(ItemType.SteelSword));
        inventory.Add(ItemManager.Instance.GetNewEquipmentItem(ItemType.WoodBow));
        inventory.Add(ItemManager.Instance.GetNewEquipmentItem(ItemType.WoodShiled));
    }

    private bool LevelUP()
    {
        if (exp < maxExp)
            return false;
        
        lv++;
        exp -= maxExp;
        return true;
    }

    private void CallStatSO()
    {
        unitName = stat.unitName;
        lv = stat.lv;
        maxExp = stat.maxExp;
        exp = stat.exp;
        maxHp = stat.maxHp;
        hp = maxHp;
        atk = stat.atk;
        def = stat.def;
        criticalChance = stat.criticalChance;
        gold = stat.gold;
    }
}
