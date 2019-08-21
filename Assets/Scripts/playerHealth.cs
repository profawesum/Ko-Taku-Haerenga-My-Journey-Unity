using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    [SerializeField] totem pickupTotem;

    public AudioSource Collect;
    public AudioSource jump;
    public AudioSource hit;

    public int maxHealth = 100;
    public float currentHealth = 100;
    public int enemyWeaponDamage;

    public GameObject player;

    public GameObject destructor;

    public Image healthBar;
    public Image healthBar2;

    int timer;

    private void Awake()
    {
        currentHealth = 100;
        destructor.SetActive(false);
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Space)) {
            jump.Play();
            Debug.Log("Play");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (currentHealth <= 0) {
            Application.LoadLevel(Application.loadedLevel);
        }

        timer -= 1;

        if (timer <= 0) {
            destructor.SetActive(false);
        }


        //changes the fill of the health bar
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        healthBar2.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHealth -= enemyWeaponDamage;
            hit.Play();
        }
        if (collision.gameObject.tag == "totemBlue")
        {
            Collect.Play();
            pickupTotem.brotherTotem.enabled = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "totemRed")
        {
            Collect.Play();
            pickupTotem.sisterTotem.enabled = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "greenTotem") {
            Collect.Play();
            pickupTotem.motherTotem.enabled = true;
            Destroy(collision.gameObject);
            Debug.Log("totemM");
        }
        if (collision.gameObject.tag == "yellowTotem") {
            Collect.Play();
            pickupTotem.fatherTotem.enabled = true;
            Destroy(collision.gameObject);
            Debug.Log("totem");
        }
        if (collision.gameObject.tag == "minorTotem") {
            Collect.Play();
            destructor.SetActive(true);
            Destroy(collision.gameObject);
            timer = 20;
        }
    }




}


