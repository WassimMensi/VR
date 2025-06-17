using UnityEngine;

public class melting : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 10.0f;

    private readonly Vector3 targetScale = new Vector3(0.00004f, 0.00004f, 0.00004f);

    private bool isShrinking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && !isShrinking)
        {
            StartCoroutine(Shrink());
        }
    }

    private System.Collections.IEnumerator Shrink()
    {
        isShrinking = true;
        Vector3 startScale = transform.localScale;
        float timeElapsed = 0f;

        while (timeElapsed < shrinkDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, timeElapsed / shrinkDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
