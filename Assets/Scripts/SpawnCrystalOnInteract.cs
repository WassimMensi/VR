using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCrystalOnInteract : MonoBehaviour
{
    public GameObject crystalPrefab;
    public GameObject firePrefab;
    public Transform spawnPoint;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    private bool isHeld = false;
    private bool hasSpawned = false;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.selectEntered.AddListener(_ => isHeld = true);
        interactable.selectExited.AddListener(_ => isHeld = false);
    }

    void Update()
    {
        if (!isHeld || hasSpawned) return;

        float xRotation = transform.localEulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f;

        if (Mathf.Abs(xRotation - 11.717f) < 0.5f)
        {
            if (crystalPrefab && firePrefab && spawnPoint)
            {
                Instantiate(crystalPrefab, spawnPoint.position, spawnPoint.rotation);
                Instantiate(firePrefab, spawnPoint.position, spawnPoint.rotation);
                hasSpawned = true;
            }
        }
    }
}
