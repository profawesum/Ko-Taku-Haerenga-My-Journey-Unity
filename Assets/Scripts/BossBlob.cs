using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBlob : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int healthMax;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int AnimTime;

    public float speed;

    int i;

    private float waitTime;
    public float startWaitTime;

    bool StageTwoTriggered;
    bool DeathTriggered;

    bool isPlayerInside = false;

    [SerializeField]
    public Transform[] moveSpots;

    //public Slider healthBar;
    public Animator camAnim;
    public Animator anim;

    void Start()
    {
        currentHealth = healthMax;
        anim = GetComponent<Animator>();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= healthMax/2 && StageTwoTriggered == false)
        {
            anim.SetTrigger("StageTwo");
            StageTwoTriggered = true;
        }

        else if (currentHealth <= 0 && DeathTriggered == false)
        {
            anim.SetTrigger("Death");
            DeathTriggered = true;
        }
        if(isPlayerInside == true && DeathTriggered == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    i++;
                    waitTime = startWaitTime;
                    if (i == moveSpots.Length)
                    {
                        i = 0;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
    public void setPlayerIsInside()
    {
        anim.SetTrigger("Start");
        WaitStart();
    }
    IEnumerator WaitStart()
    {
        isPlayerInside = true;
        yield return new WaitForSeconds(AnimTime);

    }
}