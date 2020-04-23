using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Text thing;
    public float waitTime;
    public float fadeInTime;

    // Start is called before the first frame update
    void Start()
    {
        thing = GetComponent<Text>();
        thing.color = new Color(1,1,1,0);
        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {
        yield return new WaitForSeconds(waitTime);
        for(float i = 0; i <= fadeInTime; i += Time.deltaTime)
        {
            thing.color = new Color(1,1,1,i/fadeInTime);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
