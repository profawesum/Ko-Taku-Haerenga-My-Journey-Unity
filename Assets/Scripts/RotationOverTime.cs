using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOverTime : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float radius;

    public float opposite;

    float angle;
    void Update()
    {
        angle += 1 * Time.deltaTime * speed;
        if(angle >= 360)
        {
            angle = 0;
        }
        if(angle <= -360)
        {
            angle = 0;
        }
        float currentx = target.transform.position.x + radius * (Mathf.Sin((angle * Mathf.PI) / 180f) * opposite);
        float currenty = target.transform.position.y + radius * (Mathf.Cos((angle * Mathf.PI) / 180f) * opposite);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(currentx, currenty), speed * Time.deltaTime);
    }
}
