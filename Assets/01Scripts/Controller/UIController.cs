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

    // 버튼 온오프
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

    // 정보 UI 열기
    public void ActiveStatusUI()
    {
        SwitchButtons(false);
        statusUI.On();
        statusUI.Refresh(GameManager.I.player);
    }

    // 인벤 UI 활성화
    public void ActiveInvenUI(Unit unit)
    {
        ChangeSlotDatas(unit);
        invenUI.Refresh(unit);
        SwitchButtons(false);
        invenUI.On();
    }

    // 아이템 슬롯들의 데이터 교체
    public void ChangeSlotDatas(Unit unit)
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
        slotMenuUI.On(slot.transform.position);
    }

    // 아이템 파괴
    public void DestroyThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}을(를) 파괴하였습니다.");

        selectedInvenSlot.owner.inven.DestoryItem(selectedInvenSlot.invenIndex);
        invenUI.Refresh(selectedInvenSlot.owner, true);
        StartCoroutine(screenLogUI.ActiveScreenLog(newText.ToString()));
        slotMenuUI.Off();
    }

    // 아이템 착용
    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{selectedInvenSlot.itemName}을(를)");

        EquipResult result = selectedInvenSlot.owner.inven.EquipItem(selectedInvenSlot.invenIndex);
        switch (result)
        {
            case EquipResult.Success:
                newText.Append("착용하였습니다.");
                break;
            case EquipResult.Remove:
                newText.Append("제거하였습니다.");
                break;
            case EquipResult.Fail:
                newText.Append("실패하였습니다.");
                break;
        }

        ChangeSlotDatas(selectedInvenSlot.owner);
        StartCoroutine(screenLogUI.ActiveScreenLog(newText.ToString()));
        slotMenuUI.Off();
    }

    // 플레이어 컨트롤러 부분
    public void CheatForMVC()
    {
        GameManager.I.player.Gold += 100; // 값만 전달하고 플레이어의 함수를 통하여 수정
        GameManager.I.player.Exp += 10;

    }

    public void CheatAddItem()
    {
        int random = Random.Range(0, 3); // 3 장비아이템 끝번호
        List<Item> inven = GameManager.I.player.inven.itemList;

        ItemManager.I.AddItem(inven, (ItemType)random);
    }
}
