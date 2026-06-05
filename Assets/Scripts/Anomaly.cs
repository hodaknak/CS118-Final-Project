using UnityEngine;
using UnityEngine.Events;

public class Anomaly : MonoBehaviour
{
    [SerializeField]
    private AnomalyManager anomalyManager;

    [SerializeField]
    private Anomaly mirror;

    [SerializeField]
    private UnityEvent activateAnomaly;

    [SerializeField]
    private UnityEvent deactivateAnomaly;

    void OnEnable()
    {
        anomalyManager.registerAnomaly(this);
    }

    public void activate(bool original)
    {
        activateAnomaly.Invoke();

        if (original && mirror != null)
            mirror.activate(false);
    }

    public void deactivate(bool original)
    {
        deactivateAnomaly.Invoke();

        if (original && mirror != null)
            mirror.deactivate(false);
    }
}
