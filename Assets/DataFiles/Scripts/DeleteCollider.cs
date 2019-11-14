using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        print("Collided with" + col.gameObject.name);
        if (col.gameObject.tag != "Deleter")
        {
            Destroy(col.gameObject);
            //Destroy(gameObject);
        }
    }
}
