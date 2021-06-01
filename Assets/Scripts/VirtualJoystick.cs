using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image JoyOut;
    private Image JoyIn;
    private Vector2 touchPosition;
    private void Awake()
    {
        JoyOut = GetComponent<Image>();
        JoyIn = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoyOut.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            touchPosition.x = (touchPosition.x / JoyOut.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / JoyOut.rectTransform.sizeDelta.y);
            touchPosition = new Vector2(touchPosition.x * 2 - 1, touchPosition.y * 2 - 1);

            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            JoyIn.rectTransform.anchoredPosition = new Vector2(touchPosition.x * JoyOut.rectTransform.sizeDelta.x / 2, touchPosition.y * JoyOut.rectTransform.sizeDelta.y / 2);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoyIn.rectTransform.anchoredPosition = Vector2.zero;
        touchPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return touchPosition.x;
    }
    public float Vertical()
    {
        return touchPosition.y;
    }
}
