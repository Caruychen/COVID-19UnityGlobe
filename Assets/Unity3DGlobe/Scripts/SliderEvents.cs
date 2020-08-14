using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderEvents : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool selected = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        selected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("The mouse click was released");
        selected = false;
    }
}
