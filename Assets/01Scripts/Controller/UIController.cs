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
    private MenuUI UM;

    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject statusUI;
    [SerializeField] GameObject slotMenuUI;
    [SerializeField] TMP_Text screenLogUI;
    private GameObject lastOpenUI;

    private WaitForSecondsRealtime popupTime;
    private StringBuilder newText;

    // �κ��丮 �κ�
    public Unit InvenViewSelectOwner;
    public ItemSlot invenViewSelectSlot;
    public List<GameObject> activeInventorys;

    private void Awake()
    {
        I = this;

        activeInventorys = new();
        newText = new();
        popupTime = new WaitForSecondsRealtime(3.0f);
    }

    private void Start()
    {
        UM = MenuUI.I;
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
    public void InactiveClickUI()
    { }

    // �κ� UI ����
    public void ActivePlayerInvenUI()
    {
        InventoryUI.SetActive(true);
        lastOpenUI = InventoryUI;
        UM.UpdatePlayerInvenUI();
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
    public void ActiveSlotMenu(Vector3 slotPos)
    {
        slotMenuUI.transform.position = slotPos;
        slotMenuUI.SetActive(true);
    }

    public void DestroyThisItem()
    {
        newText.Clear();
        newText.Append($"{invenViewSelectSlot.itemName}��(��) �ı��Ͽ����ϴ�.");
        StopCoroutine("ActiveScreenLog");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
    }

    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{invenViewSelectSlot.itemName}��(��) �����Ͽ����ϴ�.");
        StopCoroutine("ActiveScreenLog");
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
        int random = UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemType)).Length -1 ); // -1�� empty Ÿ��
        List<Item> inven = GameManager.I.player.inventory;

        ItemManager.I.AddItem(inven, (ItemType)random);
    }

    public void CheatDelItem()
    {
        List<Item> inven = GameManager.I.player.inventory;
        if (inven.Count == 0)
            return;
        
        int random = UnityEngine.Random.Range(0, inven.Count);
        inven.RemoveAt(random);
    }
}
