using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class S_PlayerMovment : MonoBehaviour
{
    private bool canRotateCam;
    private float yRotation;
    private float moveDirection;
    private Rigidbody rb;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private Camera camera;
    private GameController gameController;
    private InputAction move;
    private Vector3 forceDirection;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameController = new GameController();
    }
    private void OnEnable()
    {
        move = gameController.GameControls.Movement;
        gameController.GameControls.Enable();
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(camera) * moveSpeed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(camera) * moveSpeed;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0f;
        if (horizontalVelocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)
            rb.velocity = horizontalVelocity.normalized * maxMoveSpeed;
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = camera.transform.right;
        right.y = 0;
        return right.normalized;
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