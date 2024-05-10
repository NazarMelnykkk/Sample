using UnityEngine.EventSystems;
using UnityEngine;
/// <summary>
/// move to an object that can be dragged
/// </summary>
public class DragUIElement : MonoBehaviour, IDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
}