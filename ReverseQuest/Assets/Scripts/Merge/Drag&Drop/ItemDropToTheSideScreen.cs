using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    [SerializeField] Transform spawnPoint;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called");
        Transform itemTransform = eventData.pointerDrag.transform; //получаем transform объект брошенного в side поле
        string itemTag = itemTransform.tag; //получаем tag объекта брошенного в side поле
        GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;

        //добавляем на side поле
        Destroy(itemTransform.gameObject);
        Instantiate(itemToInstantiateTransform, spawnPoint.position, Quaternion.identity);
    }
}
