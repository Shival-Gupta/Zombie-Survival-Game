using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float verticalSensitivityMultiplier = 0.5f;
    public float smoothSpeed = 0.125f;

    void Awake()
    {
        Debug.Log("Initializing Settings script");
        DontDestroyOnLoad(this);
        LockCursor();
    }
    
    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Cursor Locked");
    }
    
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Cursor unlocked");
    }
}
