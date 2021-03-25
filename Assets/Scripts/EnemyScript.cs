using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    bool isGrounded;
    Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundMask;
    CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();

        if (GetComponent<CameraScript>().usingCamera)
        {
            Move();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            EnemyJump();
        }
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime);
    }

    void Move()
    {
        Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        charController.Move(movement * movementSpeed * Time.deltaTime);
    }

    void EnemyJump()
    {
        if (GetComponent<CameraScript>().usingCamera)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }   
    }
}
