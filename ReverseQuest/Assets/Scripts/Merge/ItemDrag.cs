using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvas = GameObject.Find("MergeCanvas").GetComponent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slot = _rectTransform;
        slot.SetAsLastSibling(); //чтобы объект отрисовывался поверх других
        _canvasGroup.blocksRaycasts = false; //чтобы лучи проходили сквозь объект
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
