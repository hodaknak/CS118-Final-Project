using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform otherTeleporter;

    private Vector3 deltaPos;

    void Start()
    {
        deltaPos = otherTeleporter.position - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position += deltaPos;
            // 10.25 12.5

            StartCoroutine(updateTag(other.gameObject));
        }
    }

    IEnumerator updateTag(GameObject other)
    {
        other.tag = "Untagged";
        yield return new WaitForSeconds(2.0f);
        other.tag = "Player";
    }
}
