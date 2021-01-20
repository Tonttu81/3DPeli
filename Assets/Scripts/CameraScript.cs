using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity;

    float xRotation = 0f;
    float yRotation;

    public bool usingCamera;

    public GameObject objectsCamera;

    public CameraScript playersCameraScript;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        yRotation = transform.rotation.y;
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

            if (Input.GetMouseButtonDown(1) && Physics.Raycast(new Ray(objectsCamera.transform.position, objectsCamera.transform.forward), out hit, 50f))
            {
                if (hit.collider.tag == "Camera" || hit.collider.tag == "Player")
                {
                    if (hit.collider.GetComponent<CameraScript>().enabled)
                    {
                        Invoke("ChangeCamera", 0.01f);
                    }
                }
            }

            // Jos pelaaja painaa R, kamera palaa takaisin pelaajan hahmon kameraan
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (GetComponent<CameraScript>() != playersCameraScript)
                {
                    usingCamera = false;
                    playersCameraScript.usingCamera = true;
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
        yRotation += mouseX;

        if (gameObject.tag == "Player")
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.Rotate(Vector3.up * mouseX);
            objectsCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            xRotation = Mathf.Clamp(xRotation, -20f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}
