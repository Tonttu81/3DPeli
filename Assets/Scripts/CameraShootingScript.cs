using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShootingScript : MonoBehaviour
{
    public float detection = 0f;
    public float cameraDetectionRange = 30f;

    //public Light light;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kun kamera on pelaajan käytössä
        if (GetComponent<CameraScript>().usingCamera)
        {
            // Jos pelaaja left klikkaa kameralla vihollista
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 50f))
            {
                if (hit.collider.tag == "Camera")
                {
                    // hajottaa kameran
                    hit.collider.GetComponent<CameraScript>().enabled = false;
                    hit.collider.GetComponent<CameraShootingScript>().enabled = false;
                    hit.collider.GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
        else // Kun kamera ei ole pelaajan käytössä
        {
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
        }
    }
}
