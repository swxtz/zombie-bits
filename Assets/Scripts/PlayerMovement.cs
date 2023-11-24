using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        xMouse = Input.GetAxis("Mouse X") * sensi;
        yMouse = Input.GetAxis("Mouse Y") * sensi;

        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        Quaternion rotation = Quaternion.Euler(xMouse, yMouse, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed);

    }
}
