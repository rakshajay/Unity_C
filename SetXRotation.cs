using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecxRotation : MonoBehaviour
{
    public FollowOnRail rail;

    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(rail.valueOut, 0, 0);
        transform.rotation = newRotation;
    }
}
