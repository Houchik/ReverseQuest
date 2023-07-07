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
        Transform itemTransform = eventData.pointerDrag.transform; //�������� transform ������ ���������� � side ����
        string itemTag = itemTransform.tag; //�������� tag ������� ���������� � side ����
        
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

            //��������� �� side ����
            Destroy(itemTransform.gameObject);
            Instantiate(itemToInstantiateTransform, _spawnPoint);
        }
    }
}
