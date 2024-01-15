using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnRail : MonoBehaviour
{
    public Transform followTransform;
    public Transform targetTransform;
    public float size = 0.5f;
    public float valueOutMin, valueOutMax, valueOut;

    void Start()
    {
        followTransform.parent = transform;
    }

    void Update()
    {
        DoFollow();
        CalculateValue();
    }

    public void DoFollow()
    {
        followTransform.position = targetTransform.position;
        float xPoxs = Mathf.Clamp(followTransform.localPosition.x, 0, size);
        followTransform.localPosition = new Vector3(xPoxs, 0, 0);
    }

    public void SnapTargetToFollow()
    {
        targetTransform.position = followTransform.position;
        targetTransform.rotation = followTransform.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.TransformPoint(new Vector3(size, 0, 0)));
    }

    void CalculateValue()
    {
        float between0and1 = Mathf.InverseLerp(0, size, followTransform.localPosition.x);
        valueOut = Mathf.Lerp(valueOutMin, valueOutMax, between0and1);
    }
}

