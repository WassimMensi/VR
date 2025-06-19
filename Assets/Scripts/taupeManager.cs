using UnityEngine;

public class taupeManager : MonoBehaviour
{
    public static taupeManager Instance;

    private int taupesTotal = 0;
    private int taupesSauvées = 0;

    [Header("Zone de téléportation à activer")]
    [SerializeField] private GameObject sortieZone;

    [Header("Son à jouer quand toutes les taupes sont libérées")]
    [SerializeField] private AudioClip firstSFX;
    [SerializeField] private AudioClip secondSFX;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();

        if (sortieZone != null)
            sortieZone.SetActive(false);
    }

    public void RegisterTaupe()
    {
        taupesTotal++;
    }

    public void TaupeLibérée()
    {
        taupesSauvées++;
        Debug.Log($"Taupe sauvée ({taupesSauvées}/{taupesTotal})");

        if (taupesSauvées >= taupesTotal)
        {
            Debug.Log("Toutes les taupes sont libérées !");

            if (audioSource != null)
            {
                if (firstSFX != null)
                    audioSource.PlayOneShot(firstSFX);

                if (secondSFX != null)
                    Invoke(nameof(PlaySecondSound), 1f);
            }

            if (sortieZone != null)
                sortieZone.SetActive(true);
        }
    }

    private void PlaySecondSound()
    {
        if (secondSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(secondSFX);
        }
    }
}
