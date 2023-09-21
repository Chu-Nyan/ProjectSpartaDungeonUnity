using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image Image;
    public TMP_Text statusText;

    public Unit owner;
    public Sprite itemSprite;
    public int invenIndex;
    public string itemName;
    public ItemType itemType;
    public bool isEquip;

    public void Initialize(Unit owner,Item item,int index)
    {
        this.owner = owner;
        itemSprite = item.itemSprite;
        invenIndex = index;
        itemName = item.itemName;
        itemType = item.itemType;
    }

    public void OnClickSlot()
    {
        UIController.I.ActiveSlotMenu(this);
    }
}
