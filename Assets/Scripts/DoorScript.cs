using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]float openPct;

    public ButtonScript buttonScript;

    public Transform closedPoint;
    public Transform openPoint;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(closedPoint.position, openPoint.position, openPct);

        openPct = Mathf.Clamp(openPct, 0f, 1f);

        if (buttonScript.pressed)
        {
            openPct += Time.deltaTime;
        }
        else
        {
            openPct -= Time.deltaTime;
        }
    }
}
