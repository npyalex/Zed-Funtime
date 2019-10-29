using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class SwapObject : MonoBehaviour
{
    public GameObject objectOne;
    public GameObject objectTwo;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean clickAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean clickHeld;
    public SteamVR_Action_Boolean grabHeld;

    private int numClicks = 0;
    private bool swapOn = false;

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
           
        }
        else if (GetClick())
        {
        }
        //else
        //{
        //    numClicks = 0;
        //}
        if (GetGrabDown() && numClicks == 0)
        {
            print("Grab" + handType);
            swapOn = !swapOn;
            Swap();
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

    void Swap()
    {
        if (swapOn == false)
        {
            objectOne.SetActive(true);
            objectTwo.SetActive(false);
        }
        if (swapOn == true)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(true);
        }
    }
}
