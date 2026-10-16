using UnityEngine;

public class LoopTrig : MonoBehaviour
{
    [SerializeField] private Transform loopStartPoint;
    [SerializeField] private AudioSource loopSound;

    private int loopCount;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        CharacterController controller = other.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        other.transform.position = loopStartPoint.position;

        if (controller != null)
            controller.enabled = true;

        loopCount++;

        if (loopSound != null)
            loopSound.Play();

        Debug.Log("Chakva: loop " + loopCount);
    }
}
