using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelChanger : MonoBehaviour
{
    static LevelChanger instance;
    public Animator animator;
    private int levelToLoad;

    public LevelScript[] levelScripts;
    public int currentLevel;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            levelScripts = gameObject.GetComponents<LevelScript>();
            foreach (LevelScript lvl in levelScripts){ lvl.enabled = false;}
            currentLevel = 0;
            levelScripts[0].enabled = true;
            DontDestroyOnLoad(gameObject);
        }
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
            levelScripts[currentLevel].enabled = true;
            print("STARTING LEVEL " + currentLevel);
        }

        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.ResetTrigger("FadeOut");
        animator.SetTrigger("FadeIn");
    }
}
