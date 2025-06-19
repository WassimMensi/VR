using UnityEngine;

public class taupeManager : MonoBehaviour
{
    public static taupeManager Instance;

    private int taupesTotal = 0;
    private int taupesSauv�es = 0;

    [Header("Zone de t�l�portation � activer")]
    [SerializeField] private GameObject sortieZone;

    [Header("Son � jouer quand toutes les taupes sont lib�r�es")]
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

    public void TaupeLib�r�e()
    {
        taupesSauv�es++;
        Debug.Log($"Taupe sauv�e ({taupesSauv�es}/{taupesTotal})");

        if (taupesSauv�es >= taupesTotal)
        {
            Debug.Log("Toutes les taupes sont lib�r�es !");

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
