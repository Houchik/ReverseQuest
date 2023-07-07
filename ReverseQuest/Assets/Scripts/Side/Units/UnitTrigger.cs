using UnityEngine;

public class UnitTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && Ally.onAllyAttacked == null)
        {
            Debug.Log(1);
            Ally.onAllyAttacked += other.GetComponent<Enemy>().GetDamage;
            foreach (Transform child in transform)
            {
                child.GetComponent<Ally>().Attack();
            }
        }

        else if (other.CompareTag("Ally") && Enemy.onEnemyAttacked == null)
        {
            Debug.Log(0);
            Enemy.onEnemyAttacked += other.GetComponent<Ally>().GetDamage;
            foreach(Transform child in transform)
            {
                child.GetComponent<Enemy>().Attack();
            }
        }

        gameObject.GetComponent<SpawnPointMover>().enabled = false;
    }
}
