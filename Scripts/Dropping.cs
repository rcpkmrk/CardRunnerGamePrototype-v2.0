using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropping : MonoBehaviour, IDropHandler 
{   
    public bool isDropped;
    public bool isJumpCard;
    public bool isDoubleJumpCard;
    public bool isDashCard;
    public void OnDrop(PointerEventData eventData)
    {   
        if(eventData.pointerDrag.CompareTag("JumpCard") && gameObject.CompareTag("CardDropArea"))
        {
            Dragging draggingScript = eventData.pointerDrag.GetComponent<Dragging>(); // Get the Dragging script
            if (draggingScript != null)
            {
                draggingScript.isTimeNormal = false;
                draggingScript.TimeScale();
                isDropped = true;
                isJumpCard = true;
                Destroy(eventData.pointerDrag);
            }
        }
        if(eventData.pointerDrag.CompareTag("DoubleJumpCard") && gameObject.CompareTag("CardDropArea"))
        {
            Dragging doubleJumpDraggingScript = eventData.pointerDrag.GetComponent<Dragging>(); // Get the Dragging script for double jump card
            if (doubleJumpDraggingScript != null)
            {
                doubleJumpDraggingScript.isTimeNormal = false;
                doubleJumpDraggingScript.TimeScale();
                isDropped = true;
                isDoubleJumpCard = true;
                Destroy(eventData.pointerDrag);
            }
        }
        if(eventData.pointerDrag.CompareTag("DashCard") && gameObject.CompareTag("CardDropArea"))
        {
            Dragging dashDraggingScript = eventData.pointerDrag.GetComponent<Dragging>(); // Get the Dragging script for dash card
            if (dashDraggingScript != null)
            {
                dashDraggingScript.isTimeNormal = false;
                dashDraggingScript.TimeScale();
                isDropped = true;
                isDashCard = true;
                Destroy(eventData.pointerDrag);
            }
        }
    }
}
