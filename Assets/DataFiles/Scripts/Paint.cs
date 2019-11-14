using System.Collections;
using System;
using Valve.VR;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public GameObject paintSource;
    public SteamVR_Input_Sources handType;
    //public SteamVR_Action_Boolean clickAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean grabHeld;
    //public SteamVR_Action_Boolean clickHeld;

    public Material lMat;
    private Rigidbody body;
    private MeshCollider banger;
    private LineRenderer currLine;
    //private Light newLight;
    //private Mesh ml;
    private int numClicks = 0;

    public bool GetGrabDown()
    {
        return grabAction.GetStateDown(handType);
    }

    public bool GetGrab()
    {
        return grabHeld.GetState(handType);
    }

    //public bool GetGrab()
    //{
    //    return grabAction.GetState(handType);
    //}
    // Start is called before the first frame update
    void Start()
    {
        //ml = GetComponent<MeshFilter>().mesh;
        //GetComponent<MeshRenderer>().material = lMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetGrabDown())
        {
            print("Grab" + handType);
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            go.AddComponent<Light>();
            //body = go.AddComponent<Rigidbody>();
            //go.AddComponent<InteractionBehaviour>();
            //body.isKinematic = false;
            //body.useGravity = false;
            //var type = Type.GetType("InteractionBehaviour");
            //go.AddComponent(type);
            //banger = go.AddComponent<MeshCollider>();
            //banger.convex = true;
            currLine = go.AddComponent<LineRenderer>();
            currLine.material = lMat;
            currLine.SetWidth(.01f, .01f);

            //currLine.SetVertexCount(1);
            //Debug.Log(paintSource.transform.position);
            //currLine.SetPosition(0, paintSource.transform.position);
            numClicks = 0;
        }
        else if (GetGrab())
        {
            print("Grab Held" + handType);
            //currLine.AddPoint(paintSource.transform.position);
            currLine.SetVertexCount(numClicks + 1);
            currLine.SetPosition(numClicks, paintSource.transform.position);
            numClicks++;
        }
        //else
        //{
        //    numClicks = 0;
        //}
        //if (GetGrab())
        //{
        //    print("Grab" + handType);
        //}
    }
}