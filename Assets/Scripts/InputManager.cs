using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMovement playerMovement;
    private FirstPersonCamera FirstPersonCamera;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMovement = GetComponent<PlayerMovement>();
        FirstPersonCamera = GetComponent<FirstPersonCamera>();
        onFoot.Jump.performed += ctx => playerMovement.Jump();
        onFoot.Crouch.started += ctx => playerMovement.Crouch();
        onFoot.Crouch.canceled += ctx => playerMovement.Stand();
        onFoot.SprintWalk.started += ctx => playerMovement.Walk();
        onFoot.SprintWalk.canceled += ctx => playerMovement.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        FirstPersonCamera.UpdateCamera(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
