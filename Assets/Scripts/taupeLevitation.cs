using UnityEngine;

public class taupeFloat : MonoBehaviour
{
    [Header("Lévitation")]
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 1f;

    [Header("Halo automatique")]
    [SerializeField] private string haloObjectName = "TaupeHaloLight";

    private GameObject haloObject;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        Transform haloTransform = transform.Find(haloObjectName);
        if (haloTransform != null)
        {
            haloObject = haloTransform.gameObject;
            haloObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"TaupeFloat: Aucun objet enfant nommé '{haloObjectName}' trouvé sur {gameObject.name}");
        }
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, offset, 0f);
    }
}
