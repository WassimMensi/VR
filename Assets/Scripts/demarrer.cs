using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class demarrer : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("level_1");
    }

    public void Quitter()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quitte le mode Play dans l'éditeur
#else
        Application.Quit(); // Ferme l'application buildée
#endif
    }
}
