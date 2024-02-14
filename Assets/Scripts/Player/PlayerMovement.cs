using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Values")]
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float RunMultiplier;

    [Header("GameObjects Helpers")]
    [SerializeField] private GameObject PlayerParent;

    [Space]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float GroundDistance;

    private Vector3 Velocity;

    private CharacterController CharacterController;

    [ReadOnly] private bool isGrounded;
    private bool InMoviment;
    private bool IsRun;

    private float Gravity = -9.8f;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();


    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        var speed = WalkSpeed;
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = WalkSpeed * RunMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        var movement = PlayerParent.transform.right * x + PlayerParent.transform.forward * z;

        CharacterController.Move(movement * speed * Time.deltaTime);

        Velocity.y += Gravity * 2f * Time.deltaTime;

        CharacterController.Move(Velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }
    }

}
