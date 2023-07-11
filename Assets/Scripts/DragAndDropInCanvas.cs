using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private RectTransform rectTransform;
    public void OnBeginDrag(PointerEventData eventData) {
        throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) {
        throw new NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData) {
        throw new NotImplementedException();
    }
}