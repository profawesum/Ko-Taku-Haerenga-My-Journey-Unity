using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatrolMove : MonoBehaviour
{
    
    public float speed;

    int i;

    private float waitTime;
    public float startWaitTime;

    [SerializeField]
    public Transform[] moveSpots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                i++;
                waitTime = startWaitTime;
                if (i == moveSpots.Length)
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
}
