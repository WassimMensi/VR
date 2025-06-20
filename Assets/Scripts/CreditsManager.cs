using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    [Header("Référence du texte de crédits")]
    public GameObject creditsText;

    public void ToggleCredits()
    {
        if (creditsText != null)
        {
            creditsText.SetActive(!creditsText.activeSelf);
        }
    }
}
