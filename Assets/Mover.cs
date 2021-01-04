using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rigidbody;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        print(GetSqrSpeed());
    }

    public void Move(Vector3 move)
    {
        rigidbody.AddRelativeForce(move);
    }

    public void Rotate(float camRotationY, float rotationTime)
    {
        float y = Mathf.SmoothDampAngle(transform.eulerAngles.y, camRotationY, ref turnSmoothVelocity, rotationTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
    }

    internal void Jump(float jumpForce)
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public float GetSqrSpeed(){
        return rigidbody.velocity.sqrMagnitude;
    }
}   
