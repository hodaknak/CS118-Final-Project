using UnityEngine;

public class SimpleAnomaly : MonoBehaviour
{
    [SerializeField]
    private GameObject normalVariant;

    private Renderer r;

    void Awake()
    {
        r = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        if (r != null)
            r.enabled = false;
    }

    public void activate()
    {
        r.enabled = true;
        normalVariant.SetActive(false);
    }

    public void deactivate()
    {
        r.enabled = false;
        normalVariant.SetActive(true);
    }
}
