using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class HUDManager : MonoBehaviour
{
    public enum HUDTextType
    {
        Name, Level, Exp, Gold
    }
    public enum HUDImageType
    {
        ExpBar
    }

    public static HUDManager I;

    private Player player;
    private StringBuilder newText;
    
    [SerializeField] private TMP_Text[] HUDTexts;
    [SerializeField] private RectTransform[] HUDImages;

    public Action updateAllHUD;
    public Action updateLvExpHUD;
    public Action updateGoldHUD;

    Vector2 fullExpSize; // 현재 Exp 막대바 표현

    private void Awake()
    {
        I = this;
        newText = new StringBuilder();

        updateAllHUD += UpdateNameUI;
        updateAllHUD += UpdateLevelAndExpUI;
        updateAllHUD += UpdateGoldUI;

        updateLvExpHUD += UpdateLevelAndExpUI;

        updateGoldHUD += UpdateGoldUI;
    }

    private void Start()
    {
        player = GameManager.I.player;

        fullExpSize = HUDImages[(int)HUDImageType.ExpBar].sizeDelta;
        updateAllHUD?.Invoke();
    }

    private void UpdateNameUI()
    {
        HUDTexts[(int)HUDTextType.Name].text = player.unitName;
    }

    private void UpdateLevelAndExpUI()
    {
        newText.Clear();
        newText.Append($"Lv.{player.lv}");
        HUDTexts[(int)HUDTextType.Level].text = newText.ToString();

        newText.Clear();
        newText.Append($"{player.Exp}/{player.maxExp}");
        HUDTexts[(int)HUDTextType.Exp].text = newText.ToString();

        
        HUDImages[(int)HUDImageType.ExpBar].sizeDelta = new Vector2((player.Exp / player.maxExp)*fullExpSize.x, fullExpSize.y);
    }

    private void UpdateGoldUI()
    {
        HUDTexts[(int)HUDTextType.Gold].text = player.Gold.ToString();
    }
}
