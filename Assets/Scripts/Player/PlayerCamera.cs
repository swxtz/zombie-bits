using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensi;
    public GameObject player;
    public Transform playerRot; 

    // Mouse Axis
    private float xMouse;
    private float yMouse;
    private Vector2 mousePos;

    public float limitRotationY = 50f;

    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * sensi *  Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        mousePos.x += xMouse;
        mousePos.y += yMouse;

        mousePos.y = Mathf.Clamp(mousePos.y, -limitRotationY, limitRotationY);

        transform.localRotation = Quaternion.Euler(-mousePos.y, mousePos.x, 0);

        // https://www.youtube.com/watch?time_continue=79&v=CxI2OBdhLno&embeds_referring_euri=https%3A%2F%2Fwww.google.com%2F&source_ve_path=MzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMjg2NjY&feature=emb_logo

    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
