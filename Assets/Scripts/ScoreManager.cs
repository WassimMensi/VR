using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Options")]
    [SerializeField] private float actualScore = 0;
    [SerializeField] private float maxScore = 10;

    [Header("Dependencies")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject teleportZone;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorSound;

    void Start()
    {
        scoreText.text = actualScore.ToString() + "/" + maxScore.ToString();
    }

    public void addScore(int score)
    {
        actualScore += score;
        if (actualScore >= maxScore)
        {
            actualScore = maxScore;
            teleportZone.SetActive(true);
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(doorSound);
        }
        scoreText.text = actualScore.ToString() + "/" + maxScore.ToString();
    }
}
