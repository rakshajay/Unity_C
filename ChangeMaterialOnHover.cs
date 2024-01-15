using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeMaterialOnHover : MonoBehaviour
{
    public List<Material> materialsToChange = new List<Material>(); // List of materials to cycle through.
    private MeshRenderer planeRenderer; // Reference to the MeshRenderer component.

    private int currentMaterialIndex = 0; // Index to track the current material.

    private void Awake()
    {
        // Get the MeshRenderer component on the plane.
        planeRenderer = GetComponent<MeshRenderer>();

        if (planeRenderer == null)
        {
            Debug.LogError("MeshRenderer component not found on the plane GameObject.");
            enabled = false; // Disable the script if the MeshRenderer is not found.
        }
    }

    // Attach this method to the XR Simple Interactable's OnHoverEntered event.
    public void OnHoverEntered(XRBaseInteractor interactor)
    {
        ChangeMaterial();
    }

    // Cycle to the next material and apply it to the plane.
    private void ChangeMaterial()
    {
        if (materialsToChange.Count == 0)
        {
            Debug.LogWarning("No materials to change.");
            return;
        }

        // Get the next material from the list.
        Material nextMaterial = materialsToChange[currentMaterialIndex];

        // Apply the material to the plane's MeshRenderer.
        planeRenderer.material = nextMaterial;

        // Increment the index to switch to the next material.
        currentMaterialIndex = (currentMaterialIndex + 1) % materialsToChange.Count;
    }
}
