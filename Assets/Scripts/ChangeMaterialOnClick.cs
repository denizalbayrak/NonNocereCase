using UnityEngine;
using TMPro;

public class ChangeMaterialOnClick : MonoBehaviour
{
    public Material newMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    public static TextMeshProUGUI selectedPartText;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        if (selectedPartText == null)
        {
            GameObject textObject = GameObject.Find("SelectedPartText");
            if (textObject != null)
                selectedPartText = textObject.GetComponent<TextMeshProUGUI>();
        }
    }

    public void OnRaycastClick()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material = objectRenderer.material == originalMaterial ? newMaterial : originalMaterial;
            UpdateSelectedPartText();
        }
    }

    private void UpdateSelectedPartText()
    {
        if (selectedPartText != null)
        {
            selectedPartText.text = "Selected part: " + gameObject.name;
        }
    }

    public void ResetMaterial()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }
}
