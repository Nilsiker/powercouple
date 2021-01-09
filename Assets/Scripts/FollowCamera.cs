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

    float adjustedDistance;


    private void Start()
    {
        adjustedDistance = distance;
    }

    // Update is called once per frame, after Update().
    private void LateUpdate()
    {
        Vector3 pos = target.position
            + target.right * xOffset
            + Vector3.up * yOffset; ;
        Follow(pos);
        Distancing(pos);
    }

    private void Follow(Vector3 pos)
    {
        transform.position = pos - target.forward * adjustedDistance;
        transform.rotation = target.rotation;
    }

    private void Distancing(Vector3 pos)
    {
        if (Physics.Raycast(pos, -target.forward, out RaycastHit hit, adjustedDistance))
        {
            adjustedDistance = Vector3.Distance(pos, hit.point);
        }
        else if (Physics.Raycast(transform.position+target.forward*0.1f, -target.forward, out RaycastHit next, distance - adjustedDistance))
        {
            adjustedDistance = Vector3.Distance(pos, next.point);
        }
        else
        {
            adjustedDistance = distance;
        }
    }

    Vector3 GetCameraForward()
    {
        return this.transform.forward;
    }
}
