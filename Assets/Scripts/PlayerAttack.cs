using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private LayerMask whatIsEnemies;
    [SerializeField]
    private float attackRangeX;
    [SerializeField]
    private float attackRangeY;
    [SerializeField]
    private int Damage;

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Debug.Log("attack Made");
                //Animation here
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(Damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
