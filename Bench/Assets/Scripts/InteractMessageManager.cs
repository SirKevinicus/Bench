using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMessageManager : MonoBehaviour
{
    public Text messageText;
    public GameObject interactPopup;
    public Camera camera;

    void Start()
    {
        interactPopup.SetActive(false);
        camera = GameObject.Find("Player").GetComponentInChildren<Camera>();
    }

    /** Done once, when there is a new item **/
    public void SetMessage(Item i)
    {
        string message = i.message.ToUpper();
        Vector3 pos = i.transform.position + i.posOffset;

        messageText.text = message;
        interactPopup.transform.position = pos;
        interactPopup.SetActive(true);
    }

    /** Performed every update **/
    public void ShowMessage()
    {
        Transform popup = interactPopup.transform;
        popup.rotation = Quaternion.LookRotation(popup.position - camera.transform.position);
    }

    public void HideMessage()
    {
        interactPopup.SetActive(false);
    }
}
