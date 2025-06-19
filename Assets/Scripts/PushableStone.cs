using UnityEngine;

public class PushableStone : MonoBehaviour
{
    public float targetZRotation = -20f;
    public float pushDuration = 0.2f;
    public GameObject[] lasersToDisable;

    private bool isPushed = false;
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private float timer = 0f;

    void Start()
    {
        originalRotation = transform.localRotation;
        targetRotation = originalRotation * Quaternion.Euler(0f, 0f, targetZRotation);
    }

    public void PushStone()
    {
        if (!isPushed)
        {
            isPushed = true;
            timer = 0f;
        }
    }

    void Update()
    {
        if (isPushed && timer < pushDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / pushDuration);
            transform.localRotation = Quaternion.Slerp(originalRotation, targetRotation, t);

            if (t >= 1f)
            {
                // Rotation terminée, détruire les lasers
                foreach (GameObject laser in lasersToDisable)
                {
                    if (laser != null)
                        Destroy(laser);
                }
            }
        }
    }
}
