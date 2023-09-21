using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public enum StatTextType
    {
        Atk,Def,Hp,Cri
    }

    public static MenuUI I;

    private StringBuilder newText;
    private Player player;

    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] TMP_Text[] statTexts;

    private void Awake()
    {
        I = this;
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

    public void UpdatePlayerInvenUI()
    {
        List<Item> playerInven = GameManager.I.player.inventory;

        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i >= playerInven.Count)
            {
                if (itemSlots[i].gameObject.activeSelf)
                {
                    itemSlots[i].gameObject.SetActive(false);
                    continue;
                }
                else
                    break;
            }

            if (itemSlots[i].itemImage.sprite == playerInven[i].itemSprite)
            {
                itemSlots[i].gameObject.SetActive(true);
                continue;
            }

            itemSlots[i].itemImage.sprite = playerInven[i].itemSprite;
            itemSlots[i].gameObject.SetActive(true);
        }
    }
}
