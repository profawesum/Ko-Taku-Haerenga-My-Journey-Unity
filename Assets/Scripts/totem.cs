using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class totem : MonoBehaviour
{

    [SerializeField] playerHealth health;
    [SerializeField] PlayerAttack attack;

    //images on the ui that represent the totems
    public Image brotherTotem;
    public Image sisterTotem;
    public Image motherTotem;
    public Image fatherTotem;

    public GameObject brotherTotemObj;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //disabling the totems in the first level;
        brotherTotem.enabled = false;
        sisterTotem.enabled = false;
        motherTotem.enabled = false;
        fatherTotem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 1 * Time.deltaTime; 
        //change attack speed
        if (fatherTotem.isActiveAndEnabled) {
            attack.startTimeBtwAttack = 2;
        }
        
        //get healing
        if (motherTotem.isActiveAndEnabled) {
            //call playerhealth 
            if (health.currentHealth < 100) {
                health.currentHealth += temp;
            }
        }
        //defend from behind
        if (brotherTotem.isActiveAndEnabled) {
            brotherTotemObj.SetActive(true);
        }
        //faster movement
        if (sisterTotem.isActiveAndEnabled) {
            //need to find a way to access the player controller
        } 
    }

    //when a boss is beaten get a new totem
    void destroyBoss(int boss) {
        if (boss == 1) {

        }
        if (boss == 2) {

        }
        if (boss == 3) {

        }
        if (boss == 4) {

        }
    }
}
