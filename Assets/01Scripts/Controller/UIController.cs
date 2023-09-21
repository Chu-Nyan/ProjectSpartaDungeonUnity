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
    public  SlotMenuUI slotMenuUI;
    [SerializeField] TMP_Text screenLogUI;

    public ItemSlot selectedInvenSlot;

    private WaitForSecondsRealtime popupTime;
    private StringBuilder newText;


    private void Awake()
    {
        I = this;

        newText = new();
        popupTime = new WaitForSecondsRealtime(3.0f);
    }

    // ���� UI ����
    public void ActiveStatusUI()
    {
        statusUI.On();
        statusUI.Refresh(GameManager.I.player);
    }

    // ��ũ�� �α�UI ���
    private IEnumerator ActiveScreenLog(string textLog)
    {
        screenLogUI.transform.parent.gameObject.SetActive(true);
        screenLogUI.text = textLog;
        yield return popupTime;
        screenLogUI.transform.parent.gameObject.SetActive(false);
    }

    #region �κ��丮 ��Ʈ�ѷ�

    // �κ� UI Ȱ��ȭ
    public void ActiveInvenUI(Unit unit)
    {
        ChangeSlotDatas(unit);
        invenUI.Refresh(unit);
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
        invenUI.Refresh(selectedInvenSlot.owner,true);
        StartCoroutine(ActiveScreenLog(newText.ToString()));
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
        invenUI.Refresh(selectedInvenSlot.owner);
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.Off();
    }
    #endregion


    // �÷��̾� ��Ʈ�ѷ� �κ�
    public void CheatForMVC()
    {
        GameManager.I.player.Gold += 100; // ���� �����ϰ� �÷��̾��� �Լ��� ���Ͽ� ����
        GameManager.I.player.Exp += 10;

    }

    public void CheatAddItem()
    {
        int random = UnityEngine.Random.Range(0, 3); // 3 �������� ����ȣ
        List<Item> inven = GameManager.I.player.inven.itemList;

        ItemManager.I.AddItem(inven, (ItemType)random);
    }
}
