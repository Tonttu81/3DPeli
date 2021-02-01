using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBoxScript : MonoBehaviour
{
    public bool broken;

    public Light cameraLight;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (broken)
        {
            cameraLight.enabled = false;
            cam.GetComponent<CameraScript>().inactive = broken;
            cam.GetComponent<SecurityCameraScript>().disabled = broken;
        }
    }
}
