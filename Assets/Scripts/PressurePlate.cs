using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    [Header("Dependencies")]
    public AudioSource audioSource;
    public AudioClip plateSound;     // Un seul son pour la plaque (monte/descend)
    public AudioClip doorSound;      // Un seul son pour la porte (ouvre/ferme)
    public GameObject teleportZone;

    [Header("Plate Movement")]
    public Transform plateVisual;
    public float pressDepth = 0.1f;
    public float pressSpeed = 10f; // Augmente pour descente plus rapide

    private Vector3 initialPosition;
    private Vector3 pressedPosition;

    private HashSet<Collider> collidersOnPlate = new HashSet<Collider>();
    private bool isPressed = false;
    private Coroutine soundSequenceCoroutine;

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
        Debug.Log("Trigger entered by: " + other.name);
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
            if (soundSequenceCoroutine != null) StopCoroutine(soundSequenceCoroutine);
            soundSequenceCoroutine = StartCoroutine(PlaySequence(true));
        }
        else if (!shouldBePressed && isPressed)
        {
            isPressed = false;
            if (soundSequenceCoroutine != null) StopCoroutine(soundSequenceCoroutine);
            soundSequenceCoroutine = StartCoroutine(PlaySequence(false));
        }
    }

    IEnumerator PlaySequence(bool pressed)
    {
        // 1. Jouer le son de la plaque plus rapidement
        float pitch = 1.5f;
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(plateSound);
        yield return new WaitForSeconds(plateSound.length / pitch);
        audioSource.pitch = 1f;

        // 2. Jouer le son de la porte à vitesse normale
        PlaySound(doorSound);

        // 3. Activer/désactiver la zone de téléportation
        teleportZone.SetActive(pressed);
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(clip);
        }
    }
}
