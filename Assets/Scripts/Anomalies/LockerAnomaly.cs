using UnityEngine;
using System.Collections.Generic;

public class LockerAnomaly : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> objects;

    private List<Material> oldMaterials;

    [SerializeField]
    private Material newMaterial;

    void OnEnable()
    {
        oldMaterials = new List<Material>();

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
