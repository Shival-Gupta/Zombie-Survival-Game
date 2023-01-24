using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => playerMovement.Jump();
        onFoot.Crouch.started += ctx => playerMovement.Crouch(true);
        onFoot.Crouch.canceled += ctx => playerMovement.Crouch(false);
        onFoot.SprintWalk.started += ctx => playerMovement.SprintWalk(true);
        onFoot.SprintWalk.canceled += ctx => playerMovement.SprintWalk(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
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
