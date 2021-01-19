using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShootingScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CameraScript>().usingCamera)
        {
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 50f))
            {
                if (hit.collider.tag == "Camera")
                {
                    hit.collider.GetComponent<CameraScript>().enabled = false;
                }
            }
        }
    }
}
