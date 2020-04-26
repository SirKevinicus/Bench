using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelScript
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowWalkInstruction(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Teach player how to walk
    private IEnumerator ShowWalkInstruction(float sec)
    {
        PopupInstruction pui = GameObject.Find("PopupInstructions").GetComponent<PopupInstruction>();
        yield return new WaitForSeconds(sec);
        pui.ShowInstruction("Walk");
    }
}
