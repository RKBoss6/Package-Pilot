using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHeldDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeldDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeldDown = false;
    }

}
