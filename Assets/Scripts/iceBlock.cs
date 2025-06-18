using UnityEngine;

public class iceBlock : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 5f;
    [SerializeField] private Vector3 targetScale = new Vector3(0.009f, 0.009f, 0.009f);
    [SerializeField] private GameObject taupe;

    private Vector3 originalScale;
    private float meltTimer = 0f;
    private bool isMelting = false;
    private bool hasMelted = false;
    private bool taupeReleased = false;

    [SerializeField] private float meltAcceleration = 3f;

    private void Start()
    {
        originalScale = transform.localScale;

        
        if (taupe != null && taupe.transform.IsChildOf(transform))
        {
            taupe.transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (isMelting && !hasMelted)
        {
            meltTimer += Time.deltaTime;

            
            float t = meltTimer / shrinkDuration;

            
            float acceleratedT = Mathf.Pow(t, meltAcceleration);

            transform.localScale = Vector3.Lerp(originalScale, targetScale, acceleratedT);

            if (t >= 1f)
            {
                hasMelted = true;

                if (taupe != null && !taupeReleased)
                {
                    taupe.AddComponent<taupeFloat>();
                    taupeReleased = true;
                }

                Destroy(gameObject);
            }
        }
    }

    public void StartMelting() => isMelting = true;
    public void StopMelting() => isMelting = false;
}
