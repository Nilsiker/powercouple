using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Mover mover;
    Vector3 moveVector;
    Transform camPivot;

    float turnSmoothVelocity;

    [Header("Player Controls")]
    [SerializeField] float maxSpeedSquared = 25;
    [SerializeField] float acceleration = 500;
    [SerializeField] float rotationTime = .12f;
    [SerializeField] float jumpForce = 4;


    [Header("Camera Controls")]
    [SerializeField] float mouseSensitivity = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        camPivot = FindObjectOfType<CamPivot>().transform;
        mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && moveVector != Vector3.zero)
        {
            Move();
        }
    }

    public void Jump()
    {
        if (IsGrounded()) mover.Jump(jumpForce);
    }

    private void Move()
    {
        if (mover.GetSqrSpeed() < maxSpeedSquared)
        {
            mover.Move(moveVector * acceleration * Time.fixedDeltaTime);
        }

        mover.Rotate(camPivot.eulerAngles.y, rotationTime);
    }

    public void SetMove(Vector2 dir)
    {
        moveVector = new Vector3(dir.x, 0, dir.y);
    }

    public void RotateCamera(Vector2 direction)
    {
        direction *= mouseSensitivity;
        camPivot.Rotate(-direction.y, direction.x, 0);
        camPivot.Rotate(0, 0, -camPivot.localEulerAngles.z);

        float x = camPivot.localEulerAngles.x;
        if(x>270) x -= 360;
        if(x > 70) camPivot.Rotate(70-x, 0, 0);
        else if(x < -70) camPivot.Rotate(-70-x, 0, 0);
    }

    private bool IsGrounded()
    {
        bool g = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        print(g);
        return Physics.Raycast(transform.position+Vector3.up*0.1f, Vector3.down, 0.2f);
    }
}
