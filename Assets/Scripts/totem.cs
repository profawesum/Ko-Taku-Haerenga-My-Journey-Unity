using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[SerializeField]
public class totem : MonoBehaviour
{

    //access to health and attack scripts
    [SerializeField] playerHealth health;
    [SerializeField] PlayerAttack attack;

    //get access to the character controller
    public UnityStandardAssets._2D.PlatformerCharacter2D controller;

    public int boss;

    //images on the ui that represent the totems
    public Image brotherTotem;
    public Image sisterTotem;
    public Image motherTotem;
    public Image fatherTotem;

    public GameObject invincBox;

    public int timer;
    public int maxTime = 100;
    public int invincTimer;
    public int invincTimerMax;

    public GameObject brotherTotemObj;

    void Start()
    {
        //disabling the totems in the first level;
        brotherTotem.enabled = false;
        sisterTotem.enabled = false;
        motherTotem.enabled = false;
        fatherTotem.enabled = false;

        brotherTotemObj.SetActive(false);
        invincBox.SetActive(false);

        destroyBoss(boss);
    }

    // Update is called once per frame
    void Update()
    {
        float regen = 1.0f * Time.deltaTime; 

        //Change base Speed
        if (fatherTotem.isActiveAndEnabled) {
            controller.m_MaxSpeed = 10f;
        }
        
        //get healing Working
        if (motherTotem.isActiveAndEnabled) {
            //call playerhealth 
            if (health.currentHealth < 100) {
                health.currentHealth += regen;
            }
        }
        //Slow Time
        if (brotherTotem.isActiveAndEnabled) {
            if (Input.GetKey(KeyCode.E) && timer >= 500) {
                timer = 0;
                Time.timeScale = 0.3f;
            }
        }
        //Temp invicibility
        if (sisterTotem.isActiveAndEnabled) {
            if (Input.GetKey(KeyCode.Q) && invincTimer >= 1500) {
                invincBox.SetActive(true);
                invincTimer = 0;
            }

        }

    }

    private void FixedUpdate()
    {
        //deactivates the slowtime
        if (Time.timeScale == 0.3f)
        {
            if (timer >= 200)
            {
                Time.timeScale = 1.0f;
            }
        }
        brotherTotem.fillAmount = (float)timer / (float)maxTime;
        timer += 1;
        //deactivates the invincibility box
        if (invincBox.activeInHierarchy)
        {
            invincTimer += 1;
            if (invincTimer >= 200)
            {
                invincBox.SetActive(false);
            }
        }
        sisterTotem.fillAmount = (float)invincTimer / (float)invincTimerMax;
        invincTimer += 1;
    }

    //when a boss is beaten get a new totem
    [SerializeField]
    void destroyBoss(int boss) {
        if (boss == 1) {
            motherTotem.enabled = true;
        }
        if (boss >= 2) {
            fatherTotem.enabled = true;
        }
        if (boss >= 3) {
            sisterTotem.enabled = true;
        }
        if (boss >= 4) {
            brotherTotem.enabled = true;
        }
    }
}
