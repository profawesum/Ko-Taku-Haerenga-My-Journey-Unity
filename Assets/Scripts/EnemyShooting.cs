using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float timeBtwShots;
    [SerializeField]
    private float startTimeBtwShots;

    [SerializeField]
    private GameObject projectile;

    private Enemy.AttackType attackType;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        attackType = GetComponentInParent<Enemy>().GetAttackType();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Fire()
    {
        if (timeBtwShots <= 0)
        {
            GameObject _bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 bulletDir = (player.position - transform.position).normalized;

            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = transform.rotation;
            _bullet.SetActive(true);
            _bullet.GetComponent<Bullet>().SetDirection(bulletDir);
            _bullet.GetComponent<Bullet>().isNotInPool = true;
            timeBtwShots = startTimeBtwShots;
        }
        else
        { 
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (attackType == Enemy.AttackType.ShootAt)
            {
                Fire();
            }
        }
    }
}
