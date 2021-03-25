using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecurityCameraScript : MonoBehaviour
{
    public bool disabled;

    public bool detected;
    public float detection = 0f;
    public float detectionRate;
    

    public ElectricalBoxScript electricalBoxScript;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            if (detected)
            {
                detection += detectionRate * Time.deltaTime;
                if (detection > 100)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                if (detection > 0)
                {
                    detection -= detectionRate * Time.deltaTime;
                }
            }
        }
    }
}

/* Vanhoja scriptejä
            // Jos pelaaja left klikkaa kameralla vihollista
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 50f))
            {
                if (hit.collider.tag == "Camera")
                {
                    // hajottaa kameran
                    hit.collider.GetComponent<CameraScript>().enabled = false;
                    hit.collider.GetComponent<SecurityCameraScript>().enabled = false;
                    hit.collider.GetComponentInChildren<Light>().enabled = false;
                }
            }
            */

/* public float cameraDetectionRange = 30f;
            Vector3 dir = (player.transform.position - transform.position).normalized;

            Debug.DrawRay(transform.position, dir * cameraDetectionRange, Color.red);

            RaycastHit scan;
            if (Physics.Raycast(new Ray(transform.position, dir), out scan, cameraDetectionRange))
            {
                if (scan.collider.tag == "Player")
                {
                    detection += 35 * Time.deltaTime;
                    if (detection >= 100)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
                else
                {
                    if (detection > 0)
                    {
                        detection -= 15 * Time.deltaTime;
                    }
                }
            }
            */
