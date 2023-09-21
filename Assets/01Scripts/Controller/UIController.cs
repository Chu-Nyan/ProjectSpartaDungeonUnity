using System;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private MenuUI UM;

    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject statusUI;
    private GameObject lastOpenUI;

    private void Start()
    {
        UM = MenuUI.I;
    }

    public void ActiveTagetUI(GameObject openUI)
    {
        openUI.SetActive(true);
        lastOpenUI = openUI;
    }

    public void ActivePlayerInvenUI()
    {
        InventoryUI.SetActive(true);
        lastOpenUI = InventoryUI;
        UM.UpdatePlayerInvenUI();
    }

    public void ActiveStatusUI()
    {
        statusUI.SetActive(true);
        lastOpenUI = statusUI;
        UM.UpdateStatusUI();
    }

    public void InactiveLastOpenUI()
    {
        lastOpenUI.SetActive(false);
    }


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
