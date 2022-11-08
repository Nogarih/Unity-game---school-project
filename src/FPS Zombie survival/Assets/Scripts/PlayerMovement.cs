using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private CharacterController charController;
    private Vector3 velocity;
    private float gravity = -9.8f;
    [SerializeField] private float speed = 6f;
    private bool isGrounded;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 input){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -1.5f;
        }

        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;

        charController.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
    }
}