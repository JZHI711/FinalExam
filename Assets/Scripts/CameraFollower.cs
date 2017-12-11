using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public Transform target;
    private Vector3 offset;
    public float smooth = 5f;
    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        var targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}
