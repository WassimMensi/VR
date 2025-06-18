using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimpleDownwardLaser : MonoBehaviour
{
    public float laserLength = 8f;       // 📏 Longueur du laser
    public float startWidth = 0.08f;     // 🔴 Épaisseur au début (modifiable dans l'inspecteur)
    public float endWidth = 0.08f;       // 🔴 Épaisseur à la fin

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = start + Vector3.down * laserLength;

        line.startWidth = startWidth;
        line.endWidth = endWidth;

        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }
}
