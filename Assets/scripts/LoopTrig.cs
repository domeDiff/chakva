using UnityEngine;

public class LoopTrig : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform loopStartPoint;
    private bool hasTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            CharacterController controller = other.GetComponent<CharacterController>();

            if(controller != null)
                controller.enabled = false;

            player.position = loopStartPoint.position;

            if (controller != null)
                controller.enabled = true;

            Debug.Log("CHAKVA: ISHITA IS TRAPPED");
        }
    }
}
