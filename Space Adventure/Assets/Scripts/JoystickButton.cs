using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
    [HideInInspector]
    public bool isPressKey;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isPressKey = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressKey = false;
    }

}
