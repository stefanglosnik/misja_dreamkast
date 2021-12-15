using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class GuzikPrawo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler// required interface when using the OnPointerDown method.
{
    public static bool prawo;
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        prawo = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        prawo = false;
    }
}