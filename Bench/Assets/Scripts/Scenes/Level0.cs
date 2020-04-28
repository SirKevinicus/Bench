using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : LevelScript
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Peaceful");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
