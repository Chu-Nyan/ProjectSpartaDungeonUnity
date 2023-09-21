using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Unit owner;
    public Image itemImage;
    public int itemIndex;
    public string itemName;
    public ItemType itemType;
    public TMP_Text statusText;
    public bool isStack;

    public void OnClickSlot()
    {
        UIController.I.InvenViewSelectOwner = owner;
        UIController.I.invenViewSelectSlot= this;
        UIController.I.ActiveSlotMenu(transform.position);
    }
}
