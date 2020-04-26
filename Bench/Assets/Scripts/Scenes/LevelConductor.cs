using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConductor : MonoBehaviour
{
    public LevelConductor instance;

    public LevelScript[] levelScripts;
    public int currentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        levelScripts = gameObject.GetComponents<LevelScript>();
        foreach (LevelScript lvl in levelScripts)
        {
            lvl.enabled = false;
        }
        currentLevel = 0;
        levelScripts[0].enabled = true;
    }

    public void NextLevel()
    {
        levelScripts[currentLevel].enabled = false;
        if (currentLevel < levelScripts.Length - 1)
        {
            currentLevel++;
            levelScripts[currentLevel].enabled = true;
        }
    }
}
