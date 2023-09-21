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
    private MenuUI UM;

    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject statusUI;
    [SerializeField] GameObject slotMenuUI;
    [SerializeField] TMP_Text screenLogUI;
    private GameObject lastOpenUI;

    private WaitForSecondsRealtime popupTime;
    private StringBuilder newText;

    // 인벤토리 부분
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
    public void InactiveClickUI()
    { }

    // 인벤 UI 열기
    public void ActivePlayerInvenUI()
    {
        InventoryUI.SetActive(true);
        lastOpenUI = InventoryUI;
        UM.UpdatePlayerInvenUI();
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
    public void ActiveSlotMenu(Vector3 slotPos)
    {
        slotMenuUI.transform.position = slotPos;
        slotMenuUI.SetActive(true);
    }

    public void DestroyThisItem()
    {
        newText.Clear();
        newText.Append($"{invenViewSelectSlot.itemName}을(를) 파괴하였습니다.");
        StopCoroutine("ActiveScreenLog");
        StartCoroutine(ActiveScreenLog(newText.ToString()));
        slotMenuUI.SetActive(false);
    }

    public void EquipThisItem()
    {
        newText.Clear();
        newText.Append($"{invenViewSelectSlot.itemName}을(를) 착용하였습니다.");
        StopCoroutine("ActiveScreenLog");
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
        int random = UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemType)).Length -1 ); // -1은 empty 타입
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
