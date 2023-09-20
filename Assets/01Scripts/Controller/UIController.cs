using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameObject lastOpenUI;

    public void ActiveTagetUI(GameObject openUI)
    {
        openUI.SetActive(true);
        lastOpenUI = openUI;
    }

    public void InactiveLastOpenUI()
    {
        lastOpenUI.SetActive(false);
    }


    // 플레이어 컨트롤러 부분
    public void CheatForMVC()
    {
        GameManager.instance.player.Gold += 100; // 값만 전달하고 플레이어의 함수를 통하여 수정
        GameManager.instance.player.Exp += 10;

    }

    private void Example()
    {
        GameManager.instance.player.atk = 0; // 변수로 바로 접근하여 수정
    }
}
