using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : Settings
{
    public Transform playerBody;
    
    float xRotation = 0f;

    public void UpdateCamera(Vector2 input)
    {
        float mouseX = input.x * mouseSensitivity * Time.deltaTime;
        float mouseY = input.y * mouseSensitivity * Time.deltaTime * verticalSensitivityMultiplier;

        xRotation = Mathf.LerpAngle(xRotation, xRotation - mouseY, Time.deltaTime * smoothSpeed);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
