using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public float ySensi;
    public float xSensi;


    float xRotation = 0f;
    float yRotation = 0f;

    private float clampLimiter = 90f;

    private Load loadConfig;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        loadConfig = new Load();

        OptionsSchema optionsSchema = loadConfig.LoadOptions();

        ySensi = optionsSchema.ySensi;
        xSensi = optionsSchema.xSensi;
    }


    void Update()
    {
        // Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * xSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensi * Time.deltaTime;

        // Rotation around the x axis (Look up and down)
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -clampLimiter, clampLimiter);

        yRotation += mouseX;

        //Apply rotation to our transform
        //Todo create custom method

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
