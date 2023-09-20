using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public Player player;
    [SerializeField] public PlayerSO playerSO;

    private void Awake()
    {
        instance = this;
    }
}
