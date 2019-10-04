using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class PrimaryButtonEvent : UnityEvent<bool> { }
public class PrimaryButtonWatcher : MonoBehaviour
{
    public PrimaryButtonEvent primaryButtonPress;

    private bool lastButtonState = false;
    private List<UnityEngine.XR.InputDevice> allDevices;
    private List<UnityEngine.XR.InputDevice> devicesWithPrimaryButton;

    // Start is called before the first frame update
    void Start()
    {
        if(primaryButtonPress == null)
        {
            primaryButtonPress = new PrimaryButtonEvent();
        }
        allDevices = new List<UnityEngine.XR.InputDevice>();
        devicesWithPrimaryButton = new List<UnityEngine.XR.InputDevice>();
        InputTracking.nodeAdded += InputTracking_nodeAdded;
    }

    private void InputTracking_nodeAdded(XRNodeState obj)
    {
        updateInputDevices();
    }

    // Update is called once per frame
    void Update()
    {
        bool tempState = false;
        bool invalidDeviceFound = false;
        foreach(var device in devicesWithPrimaryButton)
        {
            bool primaryButtonState = false;
            tempState = device.isValid // the device is still valid
                && device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState) // did get a value
                && primaryButtonState // the value we got
                || tempState; // cumulative result from other controlelrs
            if (!device.isValid)
                invalidDeviceFound = true;
        }
        
        if (tempState != lastButtonState) // button state changed since last fram
        {
            primaryButtonPress.Invoke(tempState);
            lastButtonState = tempState;
        }

        if (invalidDeviceFound || devicesWithPrimaryButton.Count ==0) // refresh device lists
        {
            updateInputDevices();
        }
    }

    void updateInputDevices()
    {
        devicesWithPrimaryButton.Clear();
        UnityEngine.XR.InputDevices.GetDevices(allDevices);
        bool discardedValue;
        foreach (var device in allDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out discardedValue))
            {
                devicesWithPrimaryButton.Add(device); // add any devices that have a primary button
            }
        }
    }
}
