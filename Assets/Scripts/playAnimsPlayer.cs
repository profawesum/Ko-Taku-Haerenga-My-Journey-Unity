using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimsPlayer : MonoBehaviour
{

    public Animator anim;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRun", true);
        }
        else {
            anim.SetBool("isRun", false);
        }
    }
}
