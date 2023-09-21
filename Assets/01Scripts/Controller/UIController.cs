using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class UIController : MonoBehaviour
{
    //공통 부분
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

    // 범용
    public void ActiveTagetUI(GameObject openUI)
    {
        openUI.SetActive(true);
        lastOpenUI = openUI;
    }
    // 마지막 UI 닫기
    public void InactiveLastOpenUI()
    {
        lastOpenUI.SetActive(false);
    }
    // 선택 UI 닫기
    public void InactiveClickUI(BaseUI target)
    {
        target.Off();
    }


    // 정보 UI 열기
    public void ActiveStatusUI()
    {
        statusUI.SetActive(true);
        lastOpenUI = statusUI;
        UM.UpdateStatusUI();
    }
    // 스크린 로그UI 출력
    private IEnumerator ActiveScreenLog(string textLog)
    {
        screenLogUI.transform.parent.gameObject.SetActive(true);
        screenLogUI.text = textLog;
        yield return popupTime;
        screenLogUI.transform.parent.gameObject.SetActive(false);
    }

    #region 인벤토리 컨트롤러

    // 인벤 UI 활성화
    public void ActiveInvenUI(Unit unit)
    {
        ChangeSlotDatas(unit);
        invenUI.Refresh(unit);
        invenUI.On();
        lastOpenUI = invenUI.gameObject;
    }

    // 아이템 슬롯 데이터 교체
    private void ChangeSlotDatas(Unit unit)
    {
        Inventory itemList = unit.inven;
        for (int i = 0; i < itemList.itemList.Count; i++)
        {
            invenUI.itemSlots[i].Initialize(unit, itemList.itemList[i], i);
        }
    }

    // 아이템 슬롯 메뉴 열기
    public void ActiveSlotMenu(ItemSlot slot)
    {
        selectedInvenSlot = slot;
        slotMenuUI.transform.position = selectedInvenSlot.transform.position;
        slotMenuUI.SetActive(true);
    }

    // 아이템 파괴
    public void DestroyThisItem()
    {
        selectedInvenSlot.owner.inven.DestoryItem(selectedInvenSlot.invenIndex);
        invenUI.Refresh(selectedInvenSlot.owner);
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}을(를) 파괴하였습니다.");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
    }

    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}을(를) 착용하였습니다.");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
    }
    #endregion











    // 플레이어 컨트롤러 부분
    public void CheatForMVC()
    {
        GameManager.I.player.Gold += 100; // 값만 전달하고 플레이어의 함수를 통하여 수정
        GameManager.I.player.Exp += 10;

    }

    public void CheatAddItem()
    {
        int random = UnityEngine.Random.Range(0, 3); // 3 장비아이템 끝번호
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
