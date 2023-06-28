using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform _spawnPoint;

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //получаем transform объект брошенного в side поле
        string itemTag = itemTransform.tag; //получаем tag объекта брошенного в side поле
        
        if (itemTag != "Spawner")
        {
            GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;

            //добавляем на side поле
            Destroy(itemTransform.gameObject);
            Instantiate(itemToInstantiateTransform, _spawnPoint);
        }
    }
}
