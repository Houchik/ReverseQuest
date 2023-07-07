using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    private Transform _unitSpawnPoint;
    private Transform _spawnPoint;

    private void Start()
    {
        _unitSpawnPoint = GameObject.Find("UnitSpawnPoint").transform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //получаем transform объект брошенного в side поле
        string itemTag = itemTransform.tag; //получаем tag объекта брошенного в side поле
        
        if (itemTag != "Spawner")
        {
            GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;
            string nameWithoutLastSymbol = itemTag.Remove(itemTag.Length - 1);
            foreach (Transform child in _unitSpawnPoint)
            {
                if(child.name == nameWithoutLastSymbol + "SpawnPoint")
                {
                    _spawnPoint = child;
                    break;
                }
            }

            //добавляем на side поле
            Destroy(itemTransform.gameObject);
            Instantiate(itemToInstantiateTransform, _spawnPoint);
        }
    }
}
