using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int incrementMovement = 100;

    private Coroutine _handleDragOperation = null;

    public bool isDragging => _handleDragOperation != null;

    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        ExternalOnPointerDown(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        ExternalOnPointerUp(eventData);
    }

    public void ExternalOnPointerDown(PointerEventData eventData)
    {
        if (_handleDragOperation == null)
            _handleDragOperation = StartCoroutine(HandleDrag(eventData));
    }
    public void ExternalOnPointerUp(PointerEventData eventData)
    {
        if (_handleDragOperation != null)
        {
            StopCoroutine(_handleDragOperation);
            _handleDragOperation = null;
        }
    }

    private IEnumerator HandleDrag(PointerEventData eventData)
    {
        Camera cam = Camera.main;
        while (true)
        {
            transform.position = cam.ScreenToWorldPoint(eventData.position) * Vector2.one;
            transform.position = new Vector2(Mathf.Round(transform.position.x / incrementMovement) * incrementMovement, Mathf.Round(transform.position.y / incrementMovement) * incrementMovement);
            yield return null;
        }
    }
}