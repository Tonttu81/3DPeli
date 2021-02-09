using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool pressed;

    float percent;

    Vector3 sleepPos;
    Vector3 activatedPos;

    private void Start()
    {
        sleepPos = transform.position;
        activatedPos = transform.position + new Vector3(0f, -0.3f, 0f);
    }

    void Update()
    {
        percent = Mathf.Clamp(percent, 0f, 1f);

        transform.position = Vector3.Lerp(sleepPos, activatedPos, percent);

        if (pressed)
        {
            percent += 2 * Time.deltaTime;
        }
        else
        {
            percent -= 2 * Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Camera" || other.tag == "ControllableEnemy")
        {
            pressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Camera" || other.tag == "ControllableEnemy")
        {
            pressed = false;
        }
    }
}
