using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
    }

    public void Move(Vector3 move)
    {
        rb.AddRelativeForce(move);
    }

    public void Rotate(float camRotationY, float rotationTime)
    {
        float y = Mathf.SmoothDampAngle(transform.eulerAngles.y, camRotationY, ref turnSmoothVelocity, rotationTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
    }

    internal void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public float GetSqrSpeed(){
        return rb.velocity.sqrMagnitude;
    }
}   
