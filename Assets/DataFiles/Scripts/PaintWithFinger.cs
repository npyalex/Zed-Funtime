using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWithFinger : MonoBehaviour
{
    public GameObject paintSource;
    public Material lMat;
    private Rigidbody body;
    private MeshCollider banger;
    private LineRenderer currLine;
    private int numClicks = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartPaint()
    {
        if (lMat != null) { 
        GameObject go = new GameObject();
        go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();
        //go.AddComponent<Light>();
        body = go.AddComponent<Rigidbody>();
        //go.AddComponent<InteractionBehaviour>();
        body.isKinematic = false;
        body.useGravity = false;
        //var type = Type.GetType("InteractionBehaviour");
        //go.AddComponent(type);
        banger = go.AddComponent<MeshCollider>();
        banger.convex = true;
        currLine = go.AddComponent<LineRenderer>();
        currLine.material = lMat;
        currLine.SetWidth(.01f, .01f);
        numClicks = 0;
        }
    }

    public void ContinuePaint()
    {
        currLine.SetVertexCount(numClicks + 1);
        currLine.SetPosition(numClicks, paintSource.transform.position);
        numClicks++;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    lMat = collision.gameObject.GetComponent<Material>();
    //}

    //public void DeleteAll()
    //{
    //    Destroy(go.gameObject);
    //}
}
