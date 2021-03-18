using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBoxScript : MonoBehaviour
{
    bool open = false;
    public bool broken;

    Animation animation;
    public Light cameraLight;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (broken)
        {
            cameraLight.enabled = false;
            cam.GetComponent<CameraScript>().inactive = broken;
            cam.GetComponent<SecurityCameraScript>().disabled = broken;
            if (!open)
            {
                animation.Play("ebox_break");
                open = true;
            }
        }
    }
}
