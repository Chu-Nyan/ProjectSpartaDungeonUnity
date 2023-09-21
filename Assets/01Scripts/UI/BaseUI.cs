using UnityEngine;


public class BaseUI : MonoBehaviour
{
    public void On()
    {
        gameObject.SetActive(true);
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }
}
