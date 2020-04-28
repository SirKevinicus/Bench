using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public LevelScript[] levelScripts;
    public int currentLevel;

    void Awake()
    {
        levelScripts = gameObject.GetComponents<LevelScript>();
        foreach (LevelScript lvl in levelScripts){ lvl.enabled = false;}
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        levelScripts[currentLevel].enabled = true;
    }

    void Start()
    {
        print("TEST");
        levelScripts[currentLevel].StartLevelActions();
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel ()
    {
        levelScripts[currentLevel].enabled = false;
        if (currentLevel < levelScripts.Length - 1)
        {
            currentLevel++;
            print("STARTING LEVEL " + currentLevel);
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            currentLevel = 0;
            print("RETURNING TO MAIN MENU");
            FadeToLevel(currentLevel);
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        levelScripts[currentLevel].enabled = true;
        animator.ResetTrigger("FadeOut");
        animator.SetTrigger("FadeIn");
    }
}
