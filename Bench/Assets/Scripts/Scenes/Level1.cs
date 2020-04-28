using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelScript
{

    public override void StartLevelActions()
    {
        StartCoroutine(ShowWalkInstruction(3.0f));
    }

    // Teach player how to walk
    private IEnumerator ShowWalkInstruction(float sec)
    {
        PopupInstruction pui = GameObject.Find("PopupInstructions").GetComponent<PopupInstruction>();
        yield return new WaitForSeconds(sec);
        pui.ShowInstruction("Walk");
    }
}
