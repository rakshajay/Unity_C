using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubePrefabSpawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn = new List<GameObject>(); // List of prefabs to spawn.
    public List<Transform> spawnLocations = new List<Transform>();    // List of spawn locations.
    public GameObject currentSpawnedPrefab;                           // Reference to the currently spawned prefab.

    private int currentPrefabIndex = 0; // Index to track the current prefab.

    // Attach this method to the XR Simple Interactable's OnHoverEntered event.
    public void OnHoverEntered(XRBaseInteractor interactor)
    {
        SpawnNextPrefab();
    }

    // Spawn the next prefab from the list at the specified location.
    private void SpawnNextPrefab()
    {
        // Destroy the current spawned prefab if it exists.
        if (currentSpawnedPrefab != null)
        {
            Destroy(currentSpawnedPrefab);
        }

        // Check if there are any prefabs to spawn.
        if (prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("No prefabs to spawn.");
            return;
        }

        // Get the next prefab from the list.
        GameObject prefabToSpawn = prefabsToSpawn[currentPrefabIndex];

        // Get the corresponding spawn location.
        Transform spawnLocation = spawnLocations[currentPrefabIndex];

        // Instantiate the prefab at the specified location.
        currentSpawnedPrefab = Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation);

        // Increment the index to spawn the next prefab in the list.
        currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToSpawn.Count;
    }

    public void ResetSpawner()
    {
        Debug.Log("Its Working");
        // Destroy the current spawned prefab if it exists.
        if (currentSpawnedPrefab != null)
        {
            Debug.Log("Its Working inside if statement");
            Destroy(currentSpawnedPrefab);
            currentSpawnedPrefab = null; // Nullify the reference after destroying the object.
        }

        // Reset the current prefab index.
        currentPrefabIndex = 0;
    }

}
