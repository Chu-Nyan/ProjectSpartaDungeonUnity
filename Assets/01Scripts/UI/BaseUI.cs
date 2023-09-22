using UnityEngine;

public enum UIType
{
    Status,
    Inven,
    SlotMenu,
    ScreenLog,
    Button,
    Defalut
}

public class BaseUI : MonoBehaviour
{
    public UIType uiType = UIType.Defalut;

    protected virtual void Awake() { }

    public void On()
    {
        gameObject.SetActive(true);
    }

    public virtual void Off()
    {
        gameObject.SetActive(false);
    }

    public void On(Vector3 targetPos)
    {
        transform.position = targetPos;
        On();
    }
}
