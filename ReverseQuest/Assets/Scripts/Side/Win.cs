using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Debug.Log("You Won");
    }
}
