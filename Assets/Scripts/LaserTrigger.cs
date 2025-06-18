using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public Vector3 spawnPoint;  // Coordonnées du point de retour

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPoint;
        }
    }
}
