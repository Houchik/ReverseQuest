using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject _itemToSpawn;
    private int _clicksCounter;

    public void OnSpawnerClicked()
    {
        _clicksCounter++;

        if (_clicksCounter >= 3)
        {
            Destroy(gameObject);
        }

        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject slot in slots) //ищем свободный слот
        {
            if (slot.transform.childCount == 0)
            {
                Instantiate(Resources.Load("Images/" + _itemToSpawn.name), slot.transform); //создаем
                return;
            }
        }
    }
}
