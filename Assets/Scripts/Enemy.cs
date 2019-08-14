﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int health;

    public float speed;

    int i;

    private float waitTime;
    public float startWaitTime;

    [SerializeField]
    public Transform[] moveSpots;

    [SerializeField]
    private Direction direction;

    enum MovementType
    {
        Stationary,
        Patrol,
        Chase,
    }

    [SerializeField]
    private MovementType movementType;

    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[i].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                i++;
                waitTime = startWaitTime;
                if(i == moveSpots.Length)
                {
                    i = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage Done!");
    }
}
