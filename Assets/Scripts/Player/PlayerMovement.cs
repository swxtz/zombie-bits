using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public Vector3 body;

    private float gravity;

    [SerializeField]
    Rigidbody rb;

    bool isJumping = false;

    float horizontalInput;
    float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (isJumping == false)
        {
            //transform.Translate(Vector3.down * Time.deltaTime * gravity);

            
        }

        transform.Translate(Vector3.forward * velocity * Time.deltaTime * verticalInput);
    }

    private void LateUpdate()
    {
        
    }

}
