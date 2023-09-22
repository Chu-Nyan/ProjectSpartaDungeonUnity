using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class UIController : MonoBehaviour
{
    public static UIController I;

    [SerializeField] InventoryUI invenUI;
    [SerializeField] StatusUI statusUI;
    [SerializeField] ScreenLogUI screenLogUI;
    [SerializeField] ButtonUI[] buttons;
    public SlotMenuUI slotMenuUI;
    public ItemSlot selectedInvenSlot;

    private StringBuilder newText;


    private void Awake()
    {
        I = this;

        newText = new();
    }


    public void DeactivateUI(BaseUI UI)
    {
        switch (UI.uiType)
        {
            case UIType.Status:
            case UIType.Inven:
                 SwitchButtons(true);
                break;
            default:
                break;
        }
        UI.Off();
    }

    // ��ư �¿���
    public void SwitchButtons(bool isOn)
    {
        foreach (ButtonUI btn in buttons)
        {
            if (isOn == true)
                btn.On();
            else
                btn.Off();
        }
    }

    // ���� UI ����
    public void ActiveStatusUI()
    {
        SwitchButtons(false);
        statusUI.On();
        statusUI.Refresh(GameManager.I.player);
    }

    // �κ� UI Ȱ��ȭ
    public void ActiveInvenUI(Unit unit)
    {
        ChangeSlotDatas(unit);
        invenUI.Refresh(unit);
        SwitchButtons(false);
        invenUI.On();
    }

    // ������ ���Ե��� ������ ��ü
    public void ChangeSlotDatas(Unit unit)
    {
        Inventory itemList = unit.inven;
        for (int i = 0; i < itemList.itemList.Count; i++)
        {
            invenUI.itemSlots[i].Initialize(unit, itemList.itemList[i], i);
        }
    }

    // ������ ���� �޴� ����
    public void ActiveSlotMenu(ItemSlot slot)
    {
        selectedInvenSlot = slot;
        slotMenuUI.On(slot.transform.position);
    }

    // ������ �ı�
    public void DestroyThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}��(��) �ı��Ͽ����ϴ�.");

        selectedInvenSlot.owner.inven.DestoryItem(selectedInvenSlot.invenIndex);
        invenUI.Refresh(selectedInvenSlot.owner, true);
        StartCoroutine(screenLogUI.ActiveScreenLog(newText.ToString()));
        slotMenuUI.Off();
    }

    // ������ ����
    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}��(��)");

        EquipResult result = selectedInvenSlot.owner.inven.EquipItem(selectedInvenSlot.invenIndex);
        switch (result)
        {
            case EquipResult.Success:
                newText.Append("�����Ͽ����ϴ�.");
                break;
            case EquipResult.Remove:
                newText.Append("�����Ͽ����ϴ�.");
                break;
            case EquipResult.Fail:
                newText.Append("�����Ͽ����ϴ�.");
                break;
        }

        ChangeSlotDatas(selectedInvenSlot.owner);
        StartCoroutine(screenLogUI.ActiveScreenLog(newText.ToString()));
        slotMenuUI.Off();
    }

    // �÷��̾� ��Ʈ�ѷ� �κ�
    public void CheatForMVC()
    {
        GameManager.I.player.Gold += 100; // ���� �����ϰ� �÷��̾��� �Լ��� ���Ͽ� ����
        GameManager.I.player.Exp += 10;

    }

    public void CheatAddItem()
    {
        int random = Random.Range(0, 3); // 3 �������� ����ȣ
        List<Item> inven = GameManager.I.player.inven.itemList;

        ItemManager.I.AddItem(inven, (ItemType)random);
    }
}
