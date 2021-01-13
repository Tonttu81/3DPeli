using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity;

    float xRotation = 0f;

    public bool usingCamera;

    public GameObject objectsCamera;
    public LayerMask cameraMask;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingCamera)
        {
            // Aktivoi kameran
            objectsCamera.GetComponent<Camera>().enabled = enabled;

            RotateCamera();

            if (Physics.Raycast(new Ray(objectsCamera.transform.position, objectsCamera.transform.forward), out hit, 50f, cameraMask))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Invoke("ChangeCamera", 0.01f);
                }
            }
        }
        else
        {
            // Ottaa kameran pois käytöstä
            objectsCamera.GetComponent<Camera>().enabled = !enabled;
        }

        Debug.DrawRay(objectsCamera.transform.position, objectsCamera.transform.forward * 50f, Color.red);
    }

    void ChangeCamera()
    {
        usingCamera = false;
        hit.collider.GetComponent<CameraScript>().usingCamera = true;
    } 

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        objectsCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
