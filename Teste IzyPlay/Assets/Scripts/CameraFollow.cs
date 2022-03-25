using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }


}
