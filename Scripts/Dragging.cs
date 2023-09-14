using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private Vector2 initialOffset;
    Transform parentToReturnTo = null;
    public bool isTimeNormal = false;
    private GameManager gameManagerScript;
    private void Start() 
    {
        gameManagerScript = GameObject.Find("Character").GetComponent<GameManager>();
        GameObject.Find("UseCardArea");
        TimeScale();
    }
    public void OnBeginDrag(PointerEventData eventData) // when dragging starts
    {    
        initialOffset = (Vector2)transform.position - eventData.position;
        parentToReturnTo = this.transform.parent; // save the initial parent
        this.transform.SetParent(this.transform.parent.parent); // change the parent
        GetComponent<CanvasGroup>().blocksRaycasts = false; // enables the pointer see the areas while dragging
        isTimeNormal = true;
        TimeScale();
    }
    public void OnDrag(PointerEventData eventData) // while dragging
    {
        this.transform.position = eventData.position + initialOffset; // drags objects
    }
    public void OnEndDrag(PointerEventData eventData) // when dragging ends
    {
        this.transform.SetParent(parentToReturnTo); // return to former parent
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
        isTimeNormal = false;
        TimeScale();
    }
    public void TimeScale() // Scales the time
    {
        if (!isTimeNormal)
        {            
            Debug.Log("Slowed");
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Normal");
        }
    }
}