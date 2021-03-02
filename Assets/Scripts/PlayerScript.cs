using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CameraScript>().usingCamera)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit punch;

                if (Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out punch, 2f))
                {
                    if (punch.collider != null)
                    {
                        if (punch.collider.tag == "ElectricalBox")
                        {
                            punch.collider.GetComponent<ElectricalBoxScript>().broken = true;
                        }
                    }
                }
            }
        }
    }
}
