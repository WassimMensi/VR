using UnityEngine;

public class taupeFloat : MonoBehaviour
{
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 1f;
    public Color haloColor = new Color(1f, 0.85f, 0.5f); 
    public float haloIntensity = 3f;
    public float haloRange = 2f;
    public Vector3 haloOffset = new Vector3(0f, 0.5f, -0.3f);

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        GameObject halo = new GameObject("TaupeHaloLight");
        halo.transform.SetParent(transform);
        halo.transform.localPosition = haloOffset;

        Light light = halo.AddComponent<Light>();
        light.type = LightType.Point;
        light.color = haloColor;
        light.intensity = haloIntensity;
        light.range = haloRange;
        light.shadows = LightShadows.None;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, offset, 0f);
    }
}
