using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public Transform player;

    void Start()
    {
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z > -20.0f)
        {
            light1.enabled = true;
        }
        if(player.position.z > -14.0f)
        {
            light2.enabled = true;
        }
        if(player.position.z > -8.0f)
        {
            light3.enabled = true;
        }
        if(player.position.z > 14.0f)
        {
            light4.enabled = true;
        }
    }
}
