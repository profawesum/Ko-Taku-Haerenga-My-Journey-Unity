using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwap : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "finish") {
            Application.LoadLevel("sceneToLoad");
        }
    }
}
