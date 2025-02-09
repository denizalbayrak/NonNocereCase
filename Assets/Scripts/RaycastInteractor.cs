using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI; 

public class RaycastInteractor : MonoBehaviour
{
    public float rayDistance = 10f; // Max ray distance
    public LayerMask interactableLayer; 
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; 
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return; // only when the left mouse button is clicked

        if (DetectUIElement()) return; //If UI is clicked, do not process 3D object interaction

        Ray ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            ChangeMaterialOnClick materialScript = hit.collider.GetComponent<ChangeMaterialOnClick>();
            if (materialScript != null)
            {
                materialScript.OnRaycastClick();
            }

            ModelSelectButton buttonScript = hit.collider.GetComponent<ModelSelectButton>();
            if (buttonScript != null)
            {
                buttonScript.OnClick();
            }
        }
    }

    private bool IsPointerOverUIElement()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private bool DetectUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Screen.width / 2, Screen.height / 2) 
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var res in results)
        {           
            Button button = res.gameObject.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke(); 
                return true;
            }
        }
        return false;
    }
}
