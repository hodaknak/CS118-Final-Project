using UnityEngine;
using System.Collections.Generic;

public class LockerAnomaly : MonoBehaviour
{
    [SerializeField]
    private string tagName = "Locker";
    private List<Renderer> objects;

    private List<Material> oldMaterials;

    [SerializeField]
    private Material newMaterial;

    void OnEnable()
    {
        oldMaterials = new List<Material>();
        objects = new List<Renderer>();
        GameObject[] objectsArray = GameObject.FindGameObjectsWithTag(tagName);
        foreach(GameObject o in objectsArray)
        {
            Renderer r = o.GetComponent<Renderer>();
            if (r != null)
                objects.Add(r);
        }

        foreach (Renderer o in objects)
        {
            oldMaterials.Add(o.material);
        }
    }

    public void activate()
    {
        foreach (Renderer o in objects)
        {
            o.material = newMaterial;
        }
    }

    public void deactivate()
    {
        for (int i = 0; i < objects.Count; ++i)
        {
            objects[i].material = oldMaterials[i];
        }
    }
}
