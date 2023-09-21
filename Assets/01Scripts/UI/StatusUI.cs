using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public enum StatTextType
    {
        Atk,Def,Hp,Cri
    }

    public static StatusUI I;

    private StringBuilder newText;
    private Player player;

    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] TMP_Text[] statTexts;

    private void Awake()
    {
        newText = new StringBuilder();
    }

    private void Start()
    {
        player = GameManager.I.player;
    }


    public void UpdateStatusUI()
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
