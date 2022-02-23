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
        moveDirection += movement.ReadValue<Vector2>().x * CameraRight(playerCamera) * Time.deltaTime;
        moveDirection += movement.ReadValue<Vector2>().y * CameraForward(playerCamera) * Time.deltaTime;

        RB.AddForce(moveDirection, ForceMode.Impulse);
        moveDirection = Vector3.zero;

        /*float HorizontalSensitivity = 30.0f;
        float VerticalSensitivity = 30.0f;

        float RotationX = HorizontalSensitivity * LookX.ReadValue<float>() * Time.deltaTime;
        float RotationY = VerticalSensitivity * LookY.ReadValue<float>() * Time.deltaTime;

        Vector3 CamRotate = playerCamera.transform.rotation.eulerAngles;

        CamRotate.x -= RotationY;
        CamRotate.z += RotationX;

        RB.transform.rotation = Quaternion.Euler(CamRotate);*/

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
