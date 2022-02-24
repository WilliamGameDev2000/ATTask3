using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    Player inputs;
    InputAction movement;
    InputAction Look;

    Vector3 moveDirection;
    [SerializeField] Camera playerCamera;
    [SerializeField] Rigidbody RB;

    private void Awake()
    {
        inputs = new Player();
    }

    private void OnEnable()
    {
        movement = inputs.walkmap.Movement;
        movement.Enable();
        Look = inputs.walkmap.MouseLook;
        Look.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        Look.Disable();
    }

    void FixedUpdate()
    {        
        moveDirection += movement.ReadValue<Vector2>().x * CameraRight(playerCamera);
        moveDirection += movement.ReadValue<Vector2>().y * CameraForward(playerCamera);

        RB.AddForce(moveDirection, ForceMode.Impulse);
        moveDirection = Vector3.zero;

        float HorizontalSensitivity = 30.0f;
        float VerticalSensitivity = 30.0f;

        float RotationX = HorizontalSensitivity * Look.ReadValue<Vector2>().x * Time.deltaTime;
        float RotationY = VerticalSensitivity * Look.ReadValue<Vector2>().y * Time.deltaTime;

        Vector3 CamRotate = playerCamera.transform.rotation.eulerAngles;

        CamRotate.x -= RotationY;
        CamRotate.y += RotationX;

        playerCamera.transform.rotation = Quaternion.Euler(CamRotate);

    }

    private Vector3 CameraForward(Camera PlayerCamera)
    {
        Vector3 forwards = PlayerCamera.transform.forward;
        forwards.y = 0;
        return forwards.normalized;
    }

    private Vector3 CameraRight(Camera PlayerCamera)
    {
        Vector3 right = PlayerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
