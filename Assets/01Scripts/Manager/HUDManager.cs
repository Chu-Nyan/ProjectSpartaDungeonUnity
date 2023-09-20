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
}
public enum HUDImageType
{
    ExpBar
}

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    private Player player;
    private StringBuilder newText;
    
    [SerializeField] private TMP_Text[] HUDTexts;
    [SerializeField] private RectTransform[] HUDImages;
    public Action updateAllHUD;
    public Action updateLvExpHUD;
    public Action updateGoldHUD;

    Vector2 fullExpSize;

    private void Awake()
    {
        instance = this;
        newText = new StringBuilder();

        updateAllHUD += UpdateNameUI;
        updateAllHUD += UpdateLevelAndExpUI;
        updateAllHUD += UpdateGoldUI;
        updateAllHUD += UpdateStatusUI;

        updateLvExpHUD += UpdateLevelAndExpUI;

        updateGoldHUD += UpdateGoldUI;

    }

    private void Start()
    {
        player = GameManager.instance.player;

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


    //제거 할 것
    private void UpdateStatusUI()
    {
        HUDTexts[(int)HUDTextType.Atk].text = player.atk.ToString();
        HUDTexts[(int)HUDTextType.Def].text = player.def.ToString();

        newText.Clear();
        newText.Append($"{player.hp} / {player.maxHp}");
        HUDTexts[(int)HUDTextType.Hp].text = newText.ToString();

        newText.Clear();
        newText.Append($"{player.criticalChance*100:N1}%");
        HUDTexts[(int)HUDTextType.Cri].text = newText.ToString();
    }
}
