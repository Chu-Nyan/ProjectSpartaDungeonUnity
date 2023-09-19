using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public enum HUDTextType
{
    Name = 0, Level, Exp, Gold,
    Atk = 4, Def, Hp, Cri,
    Inven = 8
}

public class HUDManager : MonoBehaviour
{
    private PlayerSO playerSO;
    private StringBuilder newText;
    [SerializeField] private TMP_Text[] HUDTexts;
    
    public Action updateAllHUD;
    public Action updateLevelUp;

    private void Awake()
    {
        newText = new StringBuilder();
        updateAllHUD += UpdateNameUI;
        updateAllHUD += UpdateLevelAndExpUI;
        updateAllHUD += UpdateGoldUI;
        updateAllHUD += UpdateStatusUI;

        updateLevelUp += UpdateLevelAndExpUI;
        updateLevelUp += UpdateStatusUI;
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

    private void UpdateLevelAndExpUI()
    {
        newText.Clear();
        newText.Append($"Lv.{playerSO.lv}");
        HUDTexts[(int)HUDTextType.Level].text = newText.ToString();

        newText.Clear();
        newText.Append($"{playerSO.exp}/{playerSO.maxHp}");
        HUDTexts[(int)HUDTextType.Exp].text = newText.ToString();
    }

    private void UpdateGoldUI()
    {
        HUDTexts[(int)HUDTextType.Gold].text = playerSO.gold.ToString();
    }

    private void UpdateStatusUI()
    {
        HUDTexts[(int)HUDTextType.Atk].text = playerSO.atk.ToString();
        HUDTexts[(int)HUDTextType.Def].text = playerSO.def.ToString();

        newText.Clear();
        newText.Append($"{playerSO.hp} / {playerSO.maxHp}");
        HUDTexts[(int)HUDTextType.Hp].text = newText.ToString();

        newText.Clear();
        newText.Append($"{playerSO.criticalChance*100:N1}%");
        HUDTexts[(int)HUDTextType.Cri].text = newText.ToString();
    }
}
