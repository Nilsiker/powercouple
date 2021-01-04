using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Mover mover;
    Vector3 moveVector;

    float turnSmoothVelocity;

    [Header("Player Controls")]
    [SerializeField] float maxSpeedSquared = 25;
    [SerializeField] float acceleration = 1;
    [SerializeField] float rotationTime = .12f;
    [SerializeField] float jumpForce = 200;


    [Header("Camera Controls")]
    [SerializeField] Transform cam;
    [SerializeField] float mouseSensitivity = 5;



    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (moveVector != Vector3.zero)
        {
            Move();
        }
    }

    public void Jump()
    {
        mover.Jump(jumpForce);
    }

    private void Move()
    {
        if (mover.GetSqrSpeed() < maxSpeedSquared)
        {
            mover.Move(moveVector * acceleration * Time.fixedDeltaTime);
        }

        mover.Rotate(cam.eulerAngles.y, rotationTime);
    }

    public void SetMove(Vector2 dir)
    {
        moveVector = new Vector3(dir.x, 0, dir.y);
    }

    public void RotateCamera(Vector2 direction)
    {
        direction *= mouseSensitivity;
        cam.Rotate(-direction.y, direction.x, 0);
        cam.Rotate(0, 0, -cam.localEulerAngles.z);
    }
}
