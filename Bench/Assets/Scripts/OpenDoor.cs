using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Item
{
    Animator animator;

    void Awake() {
        message = "Open.";
        posOffset = new Vector3(0.5f, 0.8f, -0.5f);
        gameObject.layer = LayerMask.NameToLayer("Item");
        animator = gameObject.GetComponent<Animator>();
    }

    public override void InteractAction()
    {
        print("INTERACT");
        animator.SetTrigger("open_door");
        spent = true;
    }
}
