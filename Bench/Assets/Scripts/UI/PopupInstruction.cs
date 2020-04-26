using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupInstruction : MonoBehaviour
{
    public PopupInstruction instance;

    public Canvas popupCanvas;
    private CanvasGroup group;
    public Text title;
    public Instruction[] instructions;

    public GameObject WKey;
    public GameObject AKey;
    public GameObject SKey;
    public GameObject DKey;

    public float fadeTime = 1.0f;
    public float duration = 5.0f;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        group = popupCanvas.GetComponent<CanvasGroup>();
        popupCanvas.gameObject.SetActive(false);
        HideKeys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInstruction(string name)
    {
        Instruction i = Array.Find(instructions, instruction => instruction.name == name);
        title.text = i.name;
        if(i.keys == "WASD")
        {
            WKey.SetActive(true);
            AKey.SetActive(true);
            SKey.SetActive(true);
            DKey.SetActive(true);
        }
        StartCoroutine(FadeIn(fadeTime));
        StartCoroutine(WaitAndFadeOut(duration, fadeTime));
    }

    public IEnumerator FadeIn(float sec)
    {
        popupCanvas.gameObject.SetActive(true);

        group.alpha = 0;
        for (float i = 0; i <= sec; i += Time.deltaTime)
        {
            group.alpha = i / sec;
            yield return null;
        }
        group.alpha = 1;
    }

    public IEnumerator WaitAndFadeOut(float waitTime, float fadeTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            group.alpha = i / fadeTime;
            yield return null;
        }
        group.alpha = 0;
        popupCanvas.gameObject.SetActive(false);
    }

    public void HideKeys()
    {
        WKey.SetActive(false);
        AKey.SetActive(false);
        SKey.SetActive(false);
        DKey.SetActive(false);
    }

}
