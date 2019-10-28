using System.Collections;
using System;
using Valve.VR;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //public GameObject spawnSource;
    public GameObject spawnThis;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean clickAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean clickHeld;
    public SteamVR_Action_Boolean grabHeld;

    //private Vector3 sourcePosition;

    //public Material lMat;

    //private LineRenderer currLine;
    private int numClicks = 0;

    public bool GetClickDown()
    {
        return clickAction.GetStateDown(handType);
    }

    public bool GetClick()
    {
        return clickHeld.GetState(handType);
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }

    public bool GetGrabDown()
    {
        return grabHeld.GetState(handType);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetClickDown())
        {
            //print("Click" + handType);
            //GameObject go = new GameObject();
            //go.AddComponent<MeshFilter>();
            //go.AddComponent<MeshRenderer>();
            //go.AddComponent<Rigidbody>();
            //go.AddComponent<MeshCollider>();
            //currLine = go.AddComponent<LineRenderer>();
            //currLine.material = lMat;
            //currLine.SetWidth(.1f, .1f);

            //currLine.SetVertexCount(1);
            //Debug.Log(paintSource.transform.position);
            //currLine.SetPosition(0, paintSource.transform.position);
            //numClicks = 0;
        }
        else if (GetClick())
        {
            //print("Click Held" + handType);
            //currLine.AddPoint(paintSource.transform.position);
            //currLine.SetVertexCount(numClicks + 1);
            //currLine.SetPosition(numClicks, paintSource.transform.position);
            //numClicks++;
        }
        //else
        //{
        //    numClicks = 0;
        //}
        if (GetGrabDown() && numClicks == 0)
        {
            print("Grab" + handType);
            Spawn();
            numClicks++;
        }
        else if (GetGrab())
        {
            numClicks++;
        }
        else
        {
            numClicks = 0;
        }
    }

    void Spawn()
    {
        //Vector3 position = spawnSource.transform.position;
        GameObject go = Instantiate(spawnThis,transform.position,transform.rotation);
    }
}
