using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    ButtonScript buttonScript;

    public Transform closedPoint;
    public Transform openPoint;

    // Start is called before the first frame update
    void Start()
    {
        buttonScript = GetComponentInParent<ButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonScript.pressed)
        {
            transform.position = openPoint.position;
        }
        else
        {
            transform.position = closedPoint.position;
        }
    }
}
