using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportZone : MonoBehaviour
{
    //[Tooltip("Nom ou index de la sc�ne � charger")]
    public string sceneToLoad;

    //[Tooltip("Tag � d�tecter (ex: Player)")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.activeInHierarchy) return;

        if (other.CompareTag(playerTag))
        {
            Debug.Log("T�l�portation vers : " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}