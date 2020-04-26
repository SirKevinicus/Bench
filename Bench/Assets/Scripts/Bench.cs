using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : Item
{
    LevelChanger level;

    void Awake() {
        message = "SIT.";
        posOffset = new Vector3(0.0f, 1.8f, 0.0f);
        gameObject.layer = LayerMask.NameToLayer("Bench");
        level = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    public override void InteractAction()
    {
        print("INTERACT");
        level.FadeToNextLevel();
    }
}
