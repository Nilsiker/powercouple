using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float distance;

    // Update is called once per frame, after Update().
    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = target.position + new Vector3(xOffset, yOffset, distance);
    }

    Vector3 GetCameraForward()
    {
        return this.transform.forward;
    }
}
