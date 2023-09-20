using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum StatTextType
    {
        Atk,Def,Hp,Cri
    }

    public static UIManager I;
    private StringBuilder newText;
    private Player player;

    [SerializeField] private List<Image> itemSpriteList;
    [SerializeField] TMP_Text[] statText;

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
        statText[(int)StatTextType.Atk].text = player.atk.ToString();
        statText[(int)StatTextType.Def].text = player.def.ToString();

        newText.Clear();
        newText.Append($"{player.hp} / {player.maxHp}");
        statText[(int)StatTextType.Hp].text = newText.ToString();

        newText.Clear();
        newText.Append($"{player.criticalChance * 100:N1}%");
        statText[(int)StatTextType.Cri].text = newText.ToString();
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
