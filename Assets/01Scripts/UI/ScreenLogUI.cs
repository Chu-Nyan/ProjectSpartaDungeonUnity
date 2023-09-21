using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenLogUI : BaseUI
{
    [SerializeField] TMP_Text ScreenLog;

    protected override void Awake()
    {
        base.Awake();
        uiType = UIType.ScreenLog;
    }

    public IEnumerator ActiveScreenLog(string textLog)
    {
        gameObject.SetActive(true);
        ScreenLog.text = textLog;
        yield return GameManager.I.popupTime;
        gameObject.SetActive(false);
    }
}
