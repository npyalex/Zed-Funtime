using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObscurableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.renderQueue = 2002;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
