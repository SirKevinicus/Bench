using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelScript
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Stop("Peaceful");
        FindObjectOfType<AudioManager>().Play("DarkAmbient");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
