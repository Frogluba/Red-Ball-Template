using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float smoothness;
    public Transform target;
    void Update()
    {
        var pos = target.position;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos, smoothness);
    }
}
