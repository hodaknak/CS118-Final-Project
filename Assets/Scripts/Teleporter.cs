using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private AnomalyManager anomalyManager;
    [SerializeField]
    private bool front;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (front)
                other.transform.position -= new Vector3(transform.position.x, 0, transform.position.z);
            else
                transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);

            anomalyManager.teleported(front);
        }
    }
}
