using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickM : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    Vector2 touch;
    public RectTransform handle;
    float widthHalf;
    public JoystickValue value;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / (rect.sizeDelta.x *0.5f);
        if (touch.magnitude > 1)
        touch = touch.normalized;
        value.joyTouch = touch;
        handle.anchoredPosition = touch * widthHalf;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        value.joyTouch = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}