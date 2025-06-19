using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class demarrer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(){
        SceneManager.LoadScene("level_1");
    }
}
