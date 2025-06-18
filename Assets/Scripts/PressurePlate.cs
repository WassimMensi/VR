using UnityEngine;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    [Header("Dependencies")]
    public AudioSource audioSource;
    public AudioClip plateSound;     // Un seul son pour la plaque (monte/descend)
    public AudioClip doorSound;      // Un seul son pour la porte (ouvre/ferme)
    public GameObject teleportZone;

    [Header("Plate Movement")]
    public Transform plateVisual; // Visuel à déplacer
    public float pressDepth = 0.1f;
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
        PlaySound(plateSound);
        PlaySound(doorSound);
        teleportZone.SetActive(true);
    }

    void OnReleased()
    {
        PlaySound(plateSound);
        PlaySound(doorSound);
        teleportZone.SetActive(false);
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}