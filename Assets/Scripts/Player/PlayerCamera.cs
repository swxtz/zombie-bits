using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensi;

    // Mouse Axis
    private float xMouse;
    private float yMouse;
    private Vector2 mousePos;

    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * sensi;
        yMouse = Input.GetAxis("Mouse Y") * sensi;

        mousePos.x += xMouse;
        mousePos.y += yMouse;

        if(mousePos.x >= 30 ) mousePos.x = 30;
        if(mousePos.y >= -55 ) mousePos.y = -55;

        transform.localRotation = Quaternion.Euler(-mousePos.y, mousePos.x, 0);

        // https://www.youtube.com/watch?time_continue=79&v=CxI2OBdhLno&embeds_referring_euri=https%3A%2F%2Fwww.google.com%2F&source_ve_path=MzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMzY4NDIsMjg2NjY&feature=emb_logo

    }
}
