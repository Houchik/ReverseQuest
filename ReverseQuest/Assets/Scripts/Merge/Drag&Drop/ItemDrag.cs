using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private Vector2 _layoutOffset;

    private void Start()
    {
        _canvas = GameObject.Find("MergeCanvas").GetComponent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _layoutOffset = _rectTransform.anchoredPosition - eventData.position / _canvas.scaleFactor;
        _rectTransform.SetAsLastSibling();//чтобы отрисовывался поверх других
        _canvasGroup.blocksRaycasts = false; //чтобы лучи проходили сквозь        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = (eventData.position / _canvas.scaleFactor) + _layoutOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = Vector2.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
