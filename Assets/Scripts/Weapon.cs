﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;

    private UnityStandardAssets._2D.PlatformerCharacter2D playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
