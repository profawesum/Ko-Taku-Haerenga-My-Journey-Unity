using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{


    public void play() { 
        //load the first level
        Application.LoadLevel(1);
    }

    public void quit() {
        //quit the game
        Application.Quit();
    }



}
