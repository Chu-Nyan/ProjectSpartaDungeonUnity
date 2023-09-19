using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UnitStat", menuName = "SO/Unit", order = 1)]
public class UnitStatSO : ScriptableObject
{
    [Header("Base Stat")]
    public string unitName = "";
    [Range(0,99)]public int lv;
    public float maxExp;
    public float maxHp;
    public float atk;
    public float def;
    [Range(0f, 1f)] public float criticalChance;
    public float gold;
}
