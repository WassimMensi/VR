using UnityEngine;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    [Header("Dependencies")]
    public AudioSource audioSource;
    public AudioClip pressSound;
    public AudioClip releaseSound;
    public AudioClip doorUnlockSound;
    public AudioClip doorLockSound;
    public GameObject teleportZone;

    [Header("Plate Movement")]
    public Transform plateVisual; // référence au mesh ou visuel de la plaque
    public float pressDepth = 0.05f; // profondeur d'enfoncement
    public float pressSpeed = 5f;

    private Vector3 initialPosition;
    private Vector3 pressedPosition;

    private HashSet<Collider> collidersOnPlate = new HashSet<Collider>();
    private bool isPressed = false;

    void Start()
    {
        if (plateVisual == null) plateVisual = transform;
        initialPosition = plateVisual.localPosition;
        pressedPosition = initialPosition - new Vector3(0, pressDepth, 0);
    }

    void Update()
    {
        Vector3 targetPosition = isPressed ? pressedPosition : initialPosition;
        plateVisual.localPosition = Vector3.Lerp(plateVisual.localPosition, targetPosition, Time.deltaTime * pressSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        collidersOnPlate.Add(other);
        UpdatePlateState();
    }

    void OnTriggerExit(Collider other)
    {
        collidersOnPlate.Remove(other);
        UpdatePlateState();
    }

    void UpdatePlateState()
    {
        bool shouldBePressed = collidersOnPlate.Count > 0;

        if (shouldBePressed && !isPressed)
        {
            isPressed = true;
            OnPressed();
        }
        else if (!shouldBePressed && isPressed)
        {
            isPressed = false;
            OnReleased();
        }
    }

    void OnPressed()
    {
        audioSource.PlayOneShot(pressSound);
        audioSource.PlayOneShot(doorUnlockSound);
        teleportZone.SetActive(true);
    }

    void OnReleased()
    {
        audioSource.PlayOneShot(releaseSound);
        audioSource.PlayOneShot(doorLockSound);
        teleportZone.SetActive(false);
    }
}
