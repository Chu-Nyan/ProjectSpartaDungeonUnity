using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : BaseUI
{
    protected override void Awake()
    {
        uiType = UIType.Inven;
    }

    public override void Off()
    {
        base.Off();
        if (!UIController.I.slotMenuUI.gameObject.activeSelf
            || UIController.I.slotMenuUI == null)
            return;
        UIController.I.slotMenuUI.Off();
    }

    public List<ItemSlot> itemSlots;

    public void Refresh(Unit target, bool isHard = false)
    {
        if (isHard == true)
            UIController.I.ChangeSlotDatas(target);

        int checkOverCount = target.inven.itemList.Count;

        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i >= checkOverCount)
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
        }
    }
}
