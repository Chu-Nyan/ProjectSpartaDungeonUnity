using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public enum HUDTextType
{
    Name, Level, Exp, Gold, Status, Inven
}

public class HUDManager : MonoBehaviour
{
    public Action updateAllHUD;
    private PlayerSO playerSO;
    private StringBuilder newText;

    [SerializeField] private TMP_Text[] HUDTexts;


    private void Awake()
    {
        newText = new StringBuilder();
        updateAllHUD += UpdateNameUI;
        updateAllHUD += UpdateLevelAndExp;
        updateAllHUD += UpdateGold;
    }

    private void Start()
    {
        playerSO = GameManager.I.playerSO;

        updateAllHUD?.Invoke();
    }

    private void UpdateNameUI()
    {
        HUDTexts[(int)HUDTextType.Name].text = playerSO.unitName;
    }

    private void UpdateLevelAndExp()
    {
        newText.Clear();
        newText.Append($"Lv.{playerSO.lv}");
        HUDTexts[(int)HUDTextType.Level].text = newText.ToString();

        newText.Clear();
        newText.Append($"{playerSO.exp}/{playerSO.maxHp}");
        HUDTexts[(int)HUDTextType.Exp].text = newText.ToString();
    }

    private void UpdateGold()
    {
        HUDTexts[(int)HUDTextType.Gold].text = playerSO.gold.ToString();
    }
}
