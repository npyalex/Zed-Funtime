using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class ToggleCostume : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean grabHeld;
    public GameObject costumePiece;

    private int numClicks = 0;
    private bool switchOn = false;

    //manage the size of the game object
    public float scale = 0.1f;
    public float minScale = 0.1f;
    public float maxScale = 1.0f;
    public float scaleSpeed = 0.5f;

    public bool GetGrabDown()
    {
        return grabHeld.GetState(handType);
    }
    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //manage the growth and shrinkage of the object
        //when turning it on, grow it
        if (switchOn == true)
        {
            scale += scaleSpeed * Time.deltaTime;
            if (scale > maxScale)
            {
                scale = maxScale;
            }
        }
        //when turning it off, shrink it
        if (switchOn == false)
        {
            scale -= scaleSpeed * Time.deltaTime;
            if (scale < minScale)
            {
                scale = minScale;
            }
        }

        //activate once if the trigger is pressed
        if (GetGrabDown() && numClicks == 0)
        {
            print("Grab" + handType);
            Toggle();
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

    void Toggle()
    {
        //if the object is inactive, turn it on and activate the growth.
        if (switchOn == false)
        {
            switchOn = !switchOn;
            costumePiece.SetActive(true);
            costumePiece.transform.localScale = new Vector3(scale, scale, scale);
        }
        //if the object is active, activate the shrinkage and turn it off once it's at min size
        if (switchOn == true)
        {
            switchOn = !switchOn;
            costumePiece.transform.localScale = new Vector3(scale, scale, scale);
            if (scale == minScale)
            {
                costumePiece.SetActive(false);
            }
        }
    }
}
