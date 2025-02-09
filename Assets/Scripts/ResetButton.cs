using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    [SerializeField] private List<ModelSelectButton> modelSelectButtons;
    [SerializeField] private ObjectRotator objectRotator;

    private void Start()
    {
        resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(ResetAll);
    }

    private void ResetAll()
    {
        foreach (var button in modelSelectButtons)
        {
            button.ResetButtonState();
        }

        objectRotator.ResetRotation();

        ChangeMaterialOnClick[] materialChangers = FindObjectsOfType<ChangeMaterialOnClick>();
        foreach (var materialChanger in materialChangers)
        {
            materialChanger.ResetMaterial();
        }

    }
}
