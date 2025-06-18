using UnityEngine;

public class taupeFloat : MonoBehaviour
{
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, offset, 0f);
    }
}
