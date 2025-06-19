using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportZone : MonoBehaviour
{
    //[Tooltip("Nom ou index de la scène à charger")]
    public string sceneToLoad;

    //[Tooltip("Tag à détecter (ex: Player)")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.activeInHierarchy) return;

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Téléportation vers : " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}