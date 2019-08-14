using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Direction bulletDirection = Direction.RIGHT;
    public float speed = 5.0f;
    bool TimeLock = false;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TimeLock)
        {
            LifeTime();
        }
        MoveBullet();
    }
    void MoveBullet()
    {
        int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;

        float translate = moveDirection * speed * Time.deltaTime;
        _transform.Translate(translate, 0, 0);
    }

    IEnumerator LifeTime()
    {
        TimeLock = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
