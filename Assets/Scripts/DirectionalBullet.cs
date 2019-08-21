using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBullet : MonoBehaviour, IGameObjectPooled
{
    [SerializeField]
    private float moveSpeed = 10f;


    private float lifeTime;
    private float maxLifeTime = 5f;
    public Rigidbody2D rb;

    public bool isNotInPool;

    private DirectionaBulletPool pool;
    public DirectionaBulletPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
                pool = value;
            else
                throw new System.Exception("Pool is being called get set twice");
        }
    }
    private void OnEnable()
    {
        lifeTime = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * moveSpeed;
        lifeTime += Time.deltaTime;
        if(lifeTime > maxLifeTime)
        {
            pool.ReturnToPool(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Damage to player
            Destory();
        }
        else if(collision.GetComponent<DirectionalBullet>() == true)
        {
        }
        else
        {
            Destory();
        }
    }
    private void Destory()
    {
        pool.ReturnToPool(this.gameObject);
    }
}

internal interface IGameObjectPooled
{
    DirectionaBulletPool Pool { get; set; }
}
