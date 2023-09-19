using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private PlayerSO stat;

    public string unitName ="";
    public int lv;
    public float maxExp;
    public float exp;
    public float maxHp;
    public float hp;
    public float atk;
    public float def;
    public float criticalChance;
    public float gold;

    public void Awake()
    {
        CallStatSO();
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
