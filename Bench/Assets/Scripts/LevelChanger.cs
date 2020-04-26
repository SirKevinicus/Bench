using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelChanger : MonoBehaviour
{
    static LevelChanger instance;
    static LevelConductor conductor;
    public Animator animator;
    private int levelToLoad;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            conductor = gameObject.GetComponent<LevelConductor>();
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
        conductor.NextLevel();
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.ResetTrigger("FadeOut");
        animator.SetTrigger("FadeIn");
    }
}
