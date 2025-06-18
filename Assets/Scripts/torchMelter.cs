using UnityEngine;

public class torchMelter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            iceBlock iceBlock = other.GetComponent<iceBlock>();
            if (iceBlock != null)
            {
                iceBlock.StartMelting();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            iceBlock iceBlock = other.GetComponent<iceBlock>();
            if (iceBlock != null)
            {
                iceBlock.StopMelting();
            }
        }
    }
}
