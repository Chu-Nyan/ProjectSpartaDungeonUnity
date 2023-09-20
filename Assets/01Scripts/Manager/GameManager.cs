using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public Player player;
    public PlayerSO playerSO;

    private void Awake()
    {
        I = this;
    }
}
