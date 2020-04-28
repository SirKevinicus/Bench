using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    [Tooltip("The layers the items will be on")]
    private LayerMask layerMask;

    [SerializeField]
    [Tooltip("Radius when the interact button will appear")]
    private float interactRadius = 0.8f;

    private InteractMessageManager imm;
    
    private Item itemBeingInteracted;

    void Awake()
    {
        imm = GameObject.Find("ItemManager").GetComponent<InteractMessageManager>();
    }

    void Update()
    {
        SelectInteractFromRay();

        if(itemBeingInteracted != null)
        {
            imm.ShowMessage();

            if(Input.GetKeyDown(KeyCode.E))
            {
                itemBeingInteracted.InteractAction();
            }
        }
        else
        {
            imm.HideMessage();
        }
    }

    private void SelectInteractFromRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f); // 0.5,0.5,0.5
        Debug.DrawRay(ray.origin, ray.direction * interactRadius, Color.red);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo, interactRadius, layerMask))
        {
            Item hitItem = hitInfo.collider.GetComponent<Item>();

            if (hitItem == null)
            {
                itemBeingInteracted = null;
            }
            else if (hitItem != null && hitItem != itemBeingInteracted && hitItem.spent == false)
            {
                itemBeingInteracted = hitItem;
                imm.SetMessage(itemBeingInteracted);
            }
        }
        else
        {
            itemBeingInteracted = null;
        }
    }
}
