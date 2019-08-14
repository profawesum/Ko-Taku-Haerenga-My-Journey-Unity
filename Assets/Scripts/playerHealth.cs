using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;
    public int enemyWeaponDamage;

    public Image healthBar;

    // Update is called once per frame
    void Update(){
        if (currentHealth <= 0) {
            // TODO: put in gameover stuff
        }
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHealth -= enemyWeaponDamage;
        }
    }


}


