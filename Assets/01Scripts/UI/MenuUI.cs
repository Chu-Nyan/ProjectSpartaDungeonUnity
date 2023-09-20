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

    [SerializeField] private List<Image> itemSpriteList;
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

        for (int i = 0; i < itemSpriteList.Count; i++)
        {
            if (i >= playerInven.Count)
            {
                if (itemSpriteList[i].gameObject.activeSelf)
                {
                    itemSpriteList[i].gameObject.SetActive(false);
                    continue;
                }
                else
                    break;
            }

            if (itemSpriteList[i].sprite == playerInven[i].itemSprite)
            {
                itemSpriteList[i].gameObject.SetActive(true);
                continue;
            }

            itemSpriteList[i].sprite = playerInven[i].itemSprite;
            itemSpriteList[i].gameObject.SetActive(true);
        }
    }
}
