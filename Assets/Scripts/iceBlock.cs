using UnityEngine;

public class iceBlock : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 25f;
    [SerializeField] private Vector3 targetScale = new Vector3(0.00004f, 0.00004f, 0.00004f);

    private Vector3 originalScale;
    private float meltTimer = 0f;
    private bool isMelting = false;
    private bool hasMelted = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (isMelting && !hasMelted)
        {
            meltTimer += Time.deltaTime;
            float t = meltTimer / shrinkDuration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

            if (meltTimer >= shrinkDuration)
            {
                hasMelted = true;
                Destroy(gameObject); 
            }
        }
    }

    public void StartMelting()
    {
        isMelting = true;
    }

    public void StopMelting()
    {
        isMelting = false;
    }
}
