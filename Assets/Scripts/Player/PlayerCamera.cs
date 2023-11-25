using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensi;

    // Mouse Axis
    private float xMouse;
    private float yMouse;
    private float xRotation;


    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * sensi;
        yMouse = Input.GetAxis("Mouse Y") * sensi;

        //Quaternion rotation = Quaternion.Euler(xMouse, yMouse, 0);

        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);;
        transform.Rotate(xMouse, yMouse, 0);
    }
}
