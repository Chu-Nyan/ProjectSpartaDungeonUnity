using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField] public Unit player;
    [SerializeField] public PlayerSO playerSO;

    private void Awake()
    {
        I = this;
    }
}
