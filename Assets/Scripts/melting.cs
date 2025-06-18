using UnityEngine;

public class melting : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 25.0f;
    private readonly Vector3 targetScale = new Vector3(0.00004f, 0.00004f, 0.00004f);

    private bool isMelting = false;
    private float meltProgress = 0f;

    private bool torchInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            torchInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            torchInside = false;
        }
    }

    private void Update()
    {
        if (torchInside && meltProgress < shrinkDuration)
        {
            isMelting = true;
            meltProgress += Time.deltaTime;

            float t = meltProgress / shrinkDuration;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);
        }
    }
}
