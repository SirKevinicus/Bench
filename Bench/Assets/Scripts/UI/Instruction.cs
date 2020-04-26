using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Instruction
{
    public Dictionary<string, bool> KeyboardOpts = new Dictionary<string, bool>();

    public string name;
    public string message;

    public string keys;
}
