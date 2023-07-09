using UnityEngine;

public class AllyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Ally.onAllyAttacked += other.GetComponent<Enemy>().GetDamage;
            foreach (Transform child in transform)
            {
                child.GetComponent<Ally>().Attack();
            }
        }
    }
}
