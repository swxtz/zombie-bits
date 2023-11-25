using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float sensi;

    // Key WASD Our Arrows
    private float horizontalInput;
    private float verticalInput;

    // Mouse Axis
    private float xMouse;
    private float yMouse;

    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

    //}

    //private void LateUpdate()
    //{
        xMouse = Input.GetAxis("Mouse X") * sensi;
        yMouse = Input.GetAxis("Mouse Y") * sensi;

        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //Quaternion rotation = Quaternion.Euler(xMouse, yMouse, 0);

        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * xMouse);
    }
}
