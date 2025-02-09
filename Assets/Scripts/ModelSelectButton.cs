using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ModelSelectButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image buttonImage;
    [SerializeField] private GameObject selectedPart;
    [SerializeField] private Material transparentMaterial;

    private int currentStage = 0;
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        button.onClick.AddListener(OnClick);

        foreach (Renderer renderer in selectedPart.GetComponentsInChildren<Renderer>())
        {
            originalMaterials[renderer] = renderer.material;
        }
    }

    public void OnClick()
    {
        currentStage = (currentStage + 1) % 3; // 0 ➜ 1 ➜ 2 ➜ 0
        HandleStage();
    }

    public void OnRaycastClick()
    {
        OnClick(); 
    }

    private void HandleStage()
    {
        ApplyOriginalMaterials();
        ToggleChildObjects(true);
        SetButtonAlpha(255);

        switch (currentStage)
        {
            case 0:
                break;
            case 1:
                ApplyTransparentMaterial();
                SetButtonAlpha(80);
                break;
            case 2:
                ToggleChildObjects(false);
                SetButtonAlpha(0);
                break;
        }
    }

    public void ResetButtonState()
    {
        currentStage = 0; 
        HandleStage();
    }

    private void ApplyOriginalMaterials()
    {
        foreach (var renderer in originalMaterials.Keys)
        {
            if (renderer != null)
                renderer.material = originalMaterials[renderer];
        }
    }

    private void ApplyTransparentMaterial()
    {
        foreach (var renderer in selectedPart.GetComponentsInChildren<Renderer>())
        {
            if (renderer != null)
                renderer.material = transparentMaterial;
        }
    }

    private void ToggleChildObjects(bool isActive)
    {
        foreach (Transform child in selectedPart.transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

    private void SetButtonAlpha(float alphaValue)
    {
        if (buttonImage == null) return;

        Color currentColor = buttonImage.color;
        currentColor.a = alphaValue / 255f;
        buttonImage.color = currentColor;
    }
}
