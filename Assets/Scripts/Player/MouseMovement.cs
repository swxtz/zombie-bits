using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private GameObject ChestCharacter;

    [SerializeField] private float ySensi;
    [SerializeField] private float xSensi;

    // Chest Clamp
    private float MinXClamp = -45f;
    private float MaxXClamp = 45f;

    float xRotation = 0f;
    float yRotation = 0f;

    private Load loadConfig;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        LoadSensibility();
    }


    void Update()
    {
        // Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * xSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensi * Time.deltaTime;

        // Rotation around the x axis (Look up and down)
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, MinXClamp, MaxXClamp);

        yRotation += mouseX;

        //Apply rotation to our transform
        //Todo create custom method

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, yRotation, 0f);
        ChestCharacter.transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.y, 0f);
    }

    private void LoadSensibility()
    {
        loadConfig = new Load();

        OptionsSchema optionsSchema = loadConfig.LoadOptions();

        ySensi = optionsSchema.ySensi;
        xSensi = optionsSchema.xSensi;
    }
}
