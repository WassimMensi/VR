using UnityEngine;

public class RespawnIfFallen : MonoBehaviour
{
    public float fallThreshold = -10f;         // Y en dessous duquel l'objet est "perdu"
    public Vector3 respawnPosition;            // Où il réapparaît
    public Quaternion respawnRotation;         // Optionnel : angle de départ

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Enregistre la position de départ si aucune définie
        if (respawnPosition == Vector3.zero)
            respawnPosition = transform.position;

        respawnRotation = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
            Respawn();
    }

    void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(respawnPosition, respawnRotation);
    }
}
