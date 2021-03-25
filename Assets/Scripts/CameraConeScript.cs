using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConeScript : MonoBehaviour
{
    SecurityCameraScript securityCameraScript;

    // Start is called before the first frame update
    void Start()
    {
        securityCameraScript = GetComponentInParent<SecurityCameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            securityCameraScript.detected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            securityCameraScript.detected = false;
        }
    }
}
