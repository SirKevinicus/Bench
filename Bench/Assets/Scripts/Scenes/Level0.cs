using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : LevelScript
{
    public override void StartLevelActions()
    {
        AudioManager.instance.Play("Peaceful");
        AudioManager.instance.Stop("DarkAmbient");
        Cursor.lockState = CursorLockMode.None;
    }
}
