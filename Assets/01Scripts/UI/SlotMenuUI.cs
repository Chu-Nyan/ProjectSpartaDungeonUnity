using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMenuUI : BaseUI
{

    // SlotMenuUI를 InventoryUI에 넣지 않은 이유는
    // 상점이 구현된다면 인벤토리를 두 개 띄워보고 싶었습니다.
    // 그러면 따로 구현되는 게 맞지않나 생각했습니다.
    protected override void Awake()
    {
        base.Awake();
        uiType = UIType.SlotMenu;
    }


}
