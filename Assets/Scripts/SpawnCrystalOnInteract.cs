using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCrystalOnInteract : MonoBehaviour
{
    public GameObject crystalPrefab;
    public Transform spawnPoint;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        if (crystalPrefab != null && spawnPoint != null)
        {
            Instantiate(crystalPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
