using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public Player player;

    public WaitForSecondsRealtime popupTime;

    private void Awake()
    {
        I = this;
        popupTime = new WaitForSecondsRealtime(3.0f);
    }
}
