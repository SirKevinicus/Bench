using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public string message;
    public Vector3 posOffset;
    public bool spent;

    public abstract void InteractAction();

}
