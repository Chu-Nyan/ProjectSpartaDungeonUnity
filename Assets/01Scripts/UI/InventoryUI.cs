using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : BaseUI
{
    public List<ItemSlot> itemSlots;

    public void Refresh(Unit target)
    {
        int count = target.inven.itemList.Count;

        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i >= count)
            {
                if (itemSlots[i].gameObject.activeSelf)
                {
                    itemSlots[i].gameObject.SetActive(false);
                    continue;
                }
                else
                    break;
            }

            itemSlots[i].gameObject.SetActive(true);
            itemSlots[i].Image.sprite = itemSlots[i].itemSprite;
            if (itemSlots[i].isEquip == true)
            {
                itemSlots[i].statusText.text = "E";
            }
            continue;
        }
    }


}
