using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper : MonoBehaviour
{
    public static void ResetTransform(Transform t)
    {
        t.position = Vector3.zero;
        t.rotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    public static void ResetLocalTransform(Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    public static void SetTransformData(Transform t, TransformData data)
    {
        t.position = data.position;
        t.rotation = Quaternion.Euler(data.eulerAngles);
        t.localScale = data.scale;
    }
    public static void SetLocalTransformData(Transform t, TransformData data)
    {
        t.localPosition = data.position;
        t.localRotation = Quaternion.Euler(data.eulerAngles);
        t.localScale = data.scale;
    }

    public static void DeleteAllChildren(Transform t)
    {
        foreach(Transform child in t.GetComponentInChildren<Transform>())
        {
            if (child == t) continue;
            DestroyImmediate(child.gameObject);
        }
    }

    public static void LerpTransform(Transform t, Vector3 pos, float speed)
    {
        t.position = Vector3.Lerp(t.position, pos, Time.deltaTime * speed);
    }
}

[System.Serializable]
public class TransformData
{
    public Vector3 position = Vector3.zero;
    public Vector3 eulerAngles = Vector3.zero;
    public Vector3 scale = Vector3.one;
}
