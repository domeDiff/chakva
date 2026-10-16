using UnityEngine;

public class LoopTrig : MonoBehaviour
{
    [SerializeField] private Transform loopStartPoint;

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

        Debug.Log("Chakva: loop " + loopCount);
    }
}
