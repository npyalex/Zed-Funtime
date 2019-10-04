using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Success");
    }
}
