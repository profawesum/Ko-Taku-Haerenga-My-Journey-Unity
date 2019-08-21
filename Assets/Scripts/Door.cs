using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform moveSpot;

    private Transform moveBack;

    [SerializeField]
    private float speed;

    private bool isPlayerInArea;

    private bool hasPlayerTheTotem;


    // Start is called before the first frame update
    void Start()
    {
        moveBack = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isPlayerInArea == false)
        {
            isPlayerInArea = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInArea && hasPlayerTheTotem == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if(hasPlayerTheTotem == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveBack.position, speed * Time.deltaTime);
        }
    }

    void isTotemTaken()
    {
        hasPlayerTheTotem = true;
    }
}
