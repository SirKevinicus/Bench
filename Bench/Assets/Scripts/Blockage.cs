﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    public GameObject objects;
    public GameObject slideDoor;
    // Start is called before the first frame update
    void Awake()
    {
        objects = gameObject.transform.Find("Objects").gameObject;
        objects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player")
        {
            StartCoroutine(waitForDrop());
            slideDoor.GetComponent<Animator>().SetTrigger("CloseDoor");
        }
    }

    private IEnumerator waitForDrop(){
        yield return new WaitForSeconds(1.0f);
        objects.SetActive(true);
    }
}
