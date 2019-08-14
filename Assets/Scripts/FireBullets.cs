using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmounts = 10;

    [SerializeField]
    private float startAngle = 270f, endAngle = 90f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
