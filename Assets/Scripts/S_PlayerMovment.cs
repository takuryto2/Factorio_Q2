using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerMovment : MonoBehaviour
{
    private bool canRotateCam;
    private float yRotation;
    [SerializeField] private float rotationSpeed;
    public void move(InputAction.CallbackContext context)
    {

    }

    public void startRotateCamera(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            canRotateCam = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(context.canceled)
        {
            canRotateCam = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void rotateCamera(InputAction.CallbackContext context)
    {
        if(canRotateCam)
        {
            yRotation += Mathf.Clamp(context.ReadValue<Vector2>().x, -rotationSpeed, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }

}
