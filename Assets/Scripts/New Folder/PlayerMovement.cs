using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    public float crouchTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        isGrounded = characterController.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
        if (isGrounded && playerVelocity.y < 0) playerVelocity.y = -2f;
        else playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    public void Crouch()
    {
        
    }
    public void Stand()
    {

    }
    public void Walk()
    {

    }
    public void Sprint()
    {
        
    }
}
