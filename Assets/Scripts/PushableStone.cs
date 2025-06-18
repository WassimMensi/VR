using UnityEngine;

public class PushableStone : MonoBehaviour
{
    public float targetZRotation = -20f;           // angle de rotation final
    public float pushDuration = 0.2f;              // durée de l'animation
    public GameObject[] lasersToDisable;           // objets à désactiver

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

            foreach (GameObject laser in lasersToDisable)
            {
                if (laser != null)
                    Destroy(laser);
            }
        }
    }

    void Update()
    {
        if (isPushed && timer < pushDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / pushDuration);
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, t);
        }
    }
}
