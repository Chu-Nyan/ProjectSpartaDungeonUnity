using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    public enum StatTextType
    {
        Atk,Def,Hp,Cri
    }

    private StringBuilder newText;
    [SerializeField] TMP_Text[] statTexts;

    protected override void Awake()
    {
        uiType = UIType.Inven;
        newText = new StringBuilder();
    }




    public void Refresh(Player player)
    {
        statTexts[(int)StatTextType.Atk].text = player.atk.ToString();
        statTexts[(int)StatTextType.Def].text = player.def.ToString();

        newText.Clear();
        newText.Append($"{player.hp} / {player.maxHp}");
        statTexts[(int)StatTextType.Hp].text = newText.ToString();

        newText.Clear();
        newText.Append($"{player.criticalChance * 100:N1}%");
        statTexts[(int)StatTextType.Cri].text = newText.ToString();
    }


}
