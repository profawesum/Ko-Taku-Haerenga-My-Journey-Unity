using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmounts = 10;

    [SerializeField]
    private bool AlternativeFiring = false;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private float RateOfFire = 1f;

    private float fireTimer = 0;
    [SerializeField]
    private float AngleChange;

    private bool Switch;

    [SerializeField]
    private float startAngle = 270f, endAngle = 90f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Fire()
    {
        if (AlternativeFiring == true && Switch == false)
        {
            startAngle += AngleChange;
            endAngle += AngleChange;
        }
        else if (AlternativeFiring == true && Switch == true)
        {
            startAngle -= AngleChange;
            endAngle -= AngleChange;
        }
        float angleStep = (endAngle - startAngle) / bulletsAmounts;
        float angle = startAngle;
 
        for(int i = 0; i < bulletsAmounts + 1; i++)
        {
            float _bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float _bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(_bulletDirX, _bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject _bullet = BulletPool.bulletPoolInstance.GetBullet();
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = transform.rotation;
            _bullet.SetActive(true);
            _bullet.GetComponent<Bullet>().SetDirection(bulletDir);

            angle += angleStep;
            Switch = !Switch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= RateOfFire && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= maxDistance)
        {
            fireTimer = 0;
            Fire();
        }
    }
}
