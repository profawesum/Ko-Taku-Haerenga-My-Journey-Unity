using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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

    public GameObject brotherTotemObj;

    void Start()
    {
        //disabling the totems in the first level;
        brotherTotem.enabled = false;
        sisterTotem.enabled = false;
        motherTotem.enabled = false;
        fatherTotem.enabled = false;

        brotherTotemObj.SetActive(false);

        destroyBoss(boss);
    }

    // Update is called once per frame
    void Update()
    {
        float regen = 1 * Time.deltaTime; 

        //change attack speed
        if (fatherTotem.isActiveAndEnabled) {
            attack.startTimeBtwAttack = 0.2f;
        }
        
        //get healing Working
        if (motherTotem.isActiveAndEnabled) {
            //call playerhealth 
            if (health.currentHealth < 100) {
                health.currentHealth += regen;
            }
        }
        //defend from behind
        if (brotherTotem.isActiveAndEnabled) {
            brotherTotemObj.SetActive(true);
        }
        //faster movement
        if (sisterTotem.isActiveAndEnabled) {
            controller.m_MaxSpeed = 15f;
            controller.m_JumpForce = 850;
        } 
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
