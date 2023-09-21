using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerSO baseStat;

    private float exp;

    public override int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            HUD.I.updateGoldHUD();
        }
    }
    public float Exp
    {
        get { return exp; }
        set
        {
            exp = value;
            if (LevelUP())
                HUD.I.updateAllHUD();
            else
                HUD.I.updateLvExpHUD();
        }
    }

    protected override void Awake()
    {
        base.Awake();

        CallStatSO();
    }

    private void Start()
    {
        ItemManager.I.AddItem(inven.itemList, ItemType.SteelSword);
        ItemManager.I.AddItem(inven.itemList, ItemType.WoodShiled);
        ItemManager.I.AddItem(inven.itemList, ItemType.WoodBow);
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
        unitName = baseStat.unitName;
        lv = baseStat.lv;
        maxExp = baseStat.maxExp;
        exp = baseStat.exp;
        maxHp = baseStat.maxHp;
        hp = maxHp;
        atk = baseStat.atk;
        def = baseStat.def;
        criticalChance = baseStat.criticalChance;
        gold = baseStat.gold;
    }
}
