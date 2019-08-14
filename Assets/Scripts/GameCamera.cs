using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Update()
    {
        Vector3 dersiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, dersiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
