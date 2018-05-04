using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class HapticHit : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        //Debug.Log("controller should rumble now");
        Hand holdingHand = GetComponentInParent<Hand>();
        if (holdingHand)
        {
           // SteamVR_Controller.Device controller = holdingHand.controller;
            //controller.TriggerHapticPulse(50000, EVRButtonId.k_EButton_Axis0);
            //controller.TriggerHapticPulse(50000, EVRButtonId.k_EButton_Axis1);
            //controller.TriggerHapticPulse(50000, EVRButtonId.k_EButton_Axis2);
            //controller.TriggerHapticPulse(50000, EVRButtonId.k_EButton_Axis3);
            //controller.TriggerHapticPulse(50000, EVRButtonId.k_EButton_Axis4);

        }
        else {
            Debug.Log("No hand");
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
