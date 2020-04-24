using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : Item
{
    LevelChanger level;

    void Awake() {
        message = "SIT.";
        gameObject.layer = LayerMask.NameToLayer("Bench");
        level = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    public override void InteractAction()
    {
        print("INTERACT");
        level.FadeToNextLevel();
        FindObjectOfType<AudioManager>().Stop("Peaceful");
        FindObjectOfType<AudioManager>().Play("DarkAmbient");
    }
}
