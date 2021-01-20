using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    CharacterController charController;
    CameraScript cameraScript;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cameraScript = GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jos hahmon kamera on käytössä, pelaaja voi liikkua
        if (cameraScript.usingCamera)
        {
            Move();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        Gravity();        
    }

    void Move()
    {
        Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        charController.Move(movement * movementSpeed * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime);
    }
}
