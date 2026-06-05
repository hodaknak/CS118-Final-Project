using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "AnomalyManager", menuName = "Scriptable Objects/AnomalyManager")]
public class AnomalyManager : ScriptableObject
{
    public bool anomaly {get; set;}

    private List<Anomaly> anomalies;
    private GameObject[] textObjects;

    private Anomaly pickedAnomaly;
    public int score;

    private void OnEnable()
    {
        anomalies = new List<Anomaly>();
        anomaly = false;
        pickedAnomaly = null;
        textObjects = GameObject.FindGameObjectsWithTag("Text");
        score = 1;
    }

    public void updateText()
    {
        foreach (GameObject textObject in textObjects)
        {
            TextMeshProUGUI tm = textObject.GetComponent<TextMeshProUGUI>();
            if (tm != null)
                tm.text = $"Classroom {score}";
        }
    }

    public void teleported(bool front)
    {        
        Debug.Log(anomalies.Count);

        if (anomaly != front)
        {
            Debug.Log("correct");
            score += 1;
            updateText();
        }
        else
        {
            Debug.Log("incorrect");
            score = 1;
            updateText();
        }
        
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
