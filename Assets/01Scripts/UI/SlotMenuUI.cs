using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMenuUI : BaseUI
{

    // SlotMenuUI�� InventoryUI�� ���� ���� ������
    // ������ �����ȴٸ� �κ��丮�� �� �� ������� �;����ϴ�.
    // �׷��� ���� �����Ǵ� �� �����ʳ� �����߽��ϴ�.
    protected override void Awake()
    {
        base.Awake();
        uiType = UIType.SlotMenu;
    }


}
