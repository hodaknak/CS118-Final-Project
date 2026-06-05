using UnityEngine;
using System.Collections;

public class SoundAnomaly : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private float delay = 3f;

    public void activate()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        yield return new WaitForSeconds(delay);
        sound.Play();
    }

    public void deactivate()
    {
        sound.Stop();
    }
}
