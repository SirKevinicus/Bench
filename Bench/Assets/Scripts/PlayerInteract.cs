using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    [Tooltip("The layers the items will be on")]
    private LayerMask layerMask;

    [SerializeField]
    [Tooltip("Radius when the tooltip will appear")]
    private float interactRadius = 5f;

    [SerializeField]
    private Text tooltipText;
    
    private Item itemBeingInteracted;

    void Start()
    {
        tooltipText.enabled = false;
    }

    void Update()
    {
        SelectInteractFromRay();

        if(itemBeingInteracted != null)
        {
            tooltipText.enabled = true;
            tooltipText.text = itemBeingInteracted.message;
        }
        else
        {
            tooltipText.enabled = false;
        }
    }

    private void SelectInteractFromRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f); // 0.5,0.5,0.5
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo, interactRadius, layerMask))
        {
            Item hitItem = hitInfo.collider.GetComponent<Item>();

            if (hitItem == null)
            {
                itemBeingInteracted = null;
            }
            else if (hitItem != null && hitItem != itemBeingInteracted)
            {
                itemBeingInteracted = hitItem;
                print("WHADDUP!");
            }
        }
        else
        {
            itemBeingInteracted = null;
        }
    }

}
