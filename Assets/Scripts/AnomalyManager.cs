using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyManager", menuName = "Scriptable Objects/AnomalyManager")]
public class AnomalyManager : ScriptableObject
{
    public bool anomaly {get; set;}

    private List<Anomaly> anomalies;

    private Anomaly pickedAnomaly;

    private void OnEnable()
    {
        anomalies = new List<Anomaly>();
        anomaly = false;
        pickedAnomaly = null;
    }

    public void teleported(bool front)
    {        
        Debug.Log(anomalies.Count);

        if (anomaly != front)
            Debug.Log("correct");
        else
            Debug.Log("incorrect");
        
        anomaly = Random.value > 0.5f;

        if (pickedAnomaly != null)
            pickedAnomaly.deactivate(true);

        if (anomaly)
        {
            pickedAnomaly = anomalies[Random.Range(0, anomalies.Count)];
            pickedAnomaly.activate(true);
        }
    }

    public void registerAnomaly(Anomaly a)
    {
        anomalies.Add(a);
    }
}
