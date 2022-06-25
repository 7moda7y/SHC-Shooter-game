using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float sphereradius = 0.4f;
    public float jumpHight = 3f;

    public Transform groundcheck;
    public LayerMask groundMask;
    bool isgrounded;

    Vector3 velocity;

    public CharacterController controller;
    void Update()
    {

        isgrounded = Physics.CheckSphere(groundcheck.position, sphereradius, groundMask);


        if(isgrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
