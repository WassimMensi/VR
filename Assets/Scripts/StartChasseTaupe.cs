using UnityEngine;
using System;

public class StartChasseTaupe : MonoBehaviour
{
    [SerializeField] Taupe[] taupes;

    public void StartGame()
    {
        foreach (var taupe in taupes)
        {
            taupe.startGame();
        }
    }
}
