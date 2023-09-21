using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image Image;
    public TMP_Text statusText;

    public Unit owner;
    public int invenIndex;
    public ItemType itemType;
    public string itemName;
    public bool isEquiped;
    public int stack;

    public void Initialize(Unit owner,Item item,int index)
    {
        this.owner = owner;
        Image.sprite = item.itemSprite;
        invenIndex = index;
        itemName = item.itemName;
        itemType = item.itemType;
        if ((int)itemType <100)
        {
            Equipment equipment = (Equipment)item;
            isEquiped = equipment.isEquiped;
        }

        CheckEquiped();
    }

    private void CheckEquiped()
    {
        if (isEquiped == true)
        {
            statusText.text = "E";
            statusText.gameObject.SetActive(true);
        }
        else
        {
            statusText.gameObject.SetActive(false);
        }
    }

    public void OnClickSlot()
    {
        UIController.I.ActiveSlotMenu(this);
    }
}
