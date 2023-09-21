using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class UIController : MonoBehaviour
{
    //���� �κ�
    public static UIController I;
    private StatusUI UM;

    [SerializeField] InventoryUI invenUI;
    [SerializeField] GameObject statusUI;
    [SerializeField] GameObject slotMenuUI;
    [SerializeField] TMP_Text screenLogUI;

    private GameObject lastOpenUI;
    public ItemSlot selectedInvenSlot;

    private WaitForSecondsRealtime popupTime;
    private StringBuilder newText;


    private void Awake()
    {
        I = this;

        newText = new();
        popupTime = new WaitForSecondsRealtime(3.0f);
    }

    private void Start()
    {
        UM = StatusUI.I;
    }

    // ����
    public void ActiveTagetUI(GameObject openUI)
    {
        openUI.SetActive(true);
        lastOpenUI = openUI;
    }
    // ������ UI �ݱ�
    public void InactiveLastOpenUI()
    {
        lastOpenUI.SetActive(false);
    }
    // ���� UI �ݱ�
    public void InactiveClickUI(BaseUI target)
    {
        target.Off();
    }


    // ���� UI ����
    public void ActiveStatusUI()
    {
        statusUI.SetActive(true);
        lastOpenUI = statusUI;
        UM.UpdateStatusUI();
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
        lastOpenUI = invenUI.gameObject;
    }

    // ������ ���� ������ ��ü
    private void ChangeSlotDatas(Unit unit)
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
        slotMenuUI.transform.position = selectedInvenSlot.transform.position;
        slotMenuUI.SetActive(true);
    }

    // ������ �ı�
    public void DestroyThisItem()
    {
        selectedInvenSlot.owner.inven.DestoryItem(selectedInvenSlot.invenIndex);
        invenUI.Refresh(selectedInvenSlot.owner);
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}��(��) �ı��Ͽ����ϴ�.");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
    }

    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}��(��) �����Ͽ����ϴ�.");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
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

    public void CheatDelItem()
    {
        List<Item> inven = GameManager.I.player.inven.itemList;
        if (inven.Count == 0)
            return;
        
        int random = UnityEngine.Random.Range(0, inven.Count);
        inven.RemoveAt(random);
    }
}
