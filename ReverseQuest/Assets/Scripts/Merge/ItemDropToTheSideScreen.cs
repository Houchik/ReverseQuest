using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    [SerializeField] Transform plane;

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //�������� transform ������ ���������� � side ����
        string itemTag = itemTransform.tag; //�������� tag ������� ���������� � side ����
        GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;

        //��������� �� side ����
        Destroy(itemTransform.gameObject);
        Instantiate(itemToInstantiateTransform, plane.position, Quaternion.identity);
    }
}