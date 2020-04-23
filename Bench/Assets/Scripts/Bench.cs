using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : Item
{
    void Awake() {
        message = "SIT.";
    }

    public override void InteractAction()
    {
        print("INTERACT");
    }
}
