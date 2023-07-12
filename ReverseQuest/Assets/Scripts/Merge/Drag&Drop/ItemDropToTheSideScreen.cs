using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    private Transform _allySpawnPoint;

    private string _skeletonSpawner = "Skeleton_Spawner";
    private string _succubusSpawner = "Succubus_Spawner";
    private string _vampiresSpawner = "Vampire_Spawner";

    private Dictionary<string, Vector3> _allyCoordinates = new Dictionary<string, Vector3>()
    {
        {"Devil", new Vector3(0, 0, 0) },
        {"Skeleton", new Vector3(0, 0, 2) },
    };

    private void Start()
    {
        _allySpawnPoint = GameObject.Find("AllySpawnPoint").transform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //�������� transform ������ ���������� � side ����
        string itemTag = itemTransform.tag; //�������� tag ������� ���������� � side ����
        
        if (itemTag != _skeletonSpawner || itemTag != _succubusSpawner || itemTag != _vampiresSpawner)
        {
            AudioManager.Instance.PlaySfx(AudioClipName.DropUnitOnSideScreen);

            GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;
            string nameWithoutLastSymbol = itemTag.Remove(itemTag.Length - 1);

            //��������� �� side ����
            Destroy(itemTransform.gameObject);
            var createdObject = Instantiate(itemToInstantiateTransform, _allySpawnPoint);
            createdObject.transform.localPosition = _allyCoordinates[nameWithoutLastSymbol];
        }
    }
}
