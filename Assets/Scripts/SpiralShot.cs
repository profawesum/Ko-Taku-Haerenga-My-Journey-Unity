using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShot : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    DirectionaBulletPool BulletPool;

    [SerializeField]
    private float refireRate = 2f;

    private float fireTimer = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 1 * speed);
        fireTimer += Time.deltaTime;
        if(fireTimer >= refireRate)
        {
            fireTimer = 0;
            Fire();
        }
    }
    void Fire()
    {
        var shot = BulletPool.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
