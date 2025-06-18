using UnityEngine;

public class PushableStone : MonoBehaviour
{
    public float pushDistance = 0.1f;           
    public float pushDuration = 0.2f;          
    public GameObject[] lasersToDisable;       

    private bool isPushed = false;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float timer = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
        targetPosition = originalPosition + transform.right * -pushDistance;  
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
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, t);
        }
    }
}
