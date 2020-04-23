using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMessageManager : MonoBehaviour
{
    public Text messageText;
    public GameObject interactPopup;
    public Camera camera;

    /** Done once, when there is a new item **/
    public void SetMessage(Item i)
    {
        string message = i.message.ToUpper();
        Vector3 pos = i.transform.position;
        interactPopup.transform.position = new Vector3(pos.x, pos.y + 1.8f, pos.z);
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
