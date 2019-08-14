using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    private Vector2 moveDirection;

    private void OnEnable()
    {
        Invoke("Destory", 3f);
    }
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        { 
            Destory();
        }
        else
        {
            Destory();
        }
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void Destory()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
