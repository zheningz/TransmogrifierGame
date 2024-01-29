using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticLeftController : MonoBehaviour

{
    public void Update()
    {
        //if (OVRInput.Get(OVRInput.Button.One))
        //{
        //    Vib();
        //}

        //OVRInput.SetControllerVibration(1, OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger), OVRInput.Controller.LTouch);
    }

    //public void Vib()
    //{
    //    Invoke("StartVib", 0.1f);
    //    Invoke("StopVib", 0.1f);
    //}

    //public void StartVib()
    //{
    //    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
    //}

    //public void StopVib()
    //{
    //    OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
        Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
    }

    private void OnCollisionExit(Collision collision)
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
