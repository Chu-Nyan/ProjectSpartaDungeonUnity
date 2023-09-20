﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStat", menuName = "SO/Player", order = 1)]
public class PlayerSO : UnitStatSO
{
    [Header("Current Stat")]
    public float hp;
    public float exp;

    public void SaveCurrentPlayer(Player player)
    {
        hp = player.hp; 
        exp = player.Exp;
        gold = player.Gold;
    }
}
