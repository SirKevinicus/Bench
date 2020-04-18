using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject FirstPersonCam;
    public GameObject ThirdPersonCam;
    public PlayerController player;

    public int camMode;
    public bool lockCursor;

    // Start is called before the first frame update
    void Start()
    {
        ThirdPersonCam.SetActive(false);
        FirstPersonCam.SetActive(true);

        if (lockCursor){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Camera")){
            if(camMode == 1){
                camMode = 0;
            } else if(camMode == 0){
                camMode = 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange(){
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0){
            // Switch to Third Person
            ThirdPersonCam.SetActive(false);
            FirstPersonCam.SetActive(true);
            player.ChangeCameraMode(FirstPersonCam.transform);
        }
        if(camMode == 1){
            // Switch to First Person
            ThirdPersonCam.SetActive(true);
            FirstPersonCam.SetActive(false);
            player.ChangeCameraMode(ThirdPersonCam.transform);

        }
    }

    public GameObject getDefaultCamera(){
        return FirstPersonCam;
    }

    public bool isThirdPerson(){
        if(ThirdPersonCam.activeSelf) return true;
        else return false;
    }

    public bool isFirstPerson(){
        if(FirstPersonCam.activeSelf) return true;
        else return false;
    }
}
