using UnityEngine;

public class LoopTrig : MonoBehaviour
{
    [SerializeField] private Transform loopStartPoint;
    [SerializeField] private AudioSource loopSound;

    [SerializeField] private GameObject chudailPlaceholder;
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

        switch (loopCount)
        {
            case 1:
                Debug.Log("CHAKVA: The forest has looped.");
                break;

            case 2:
                Debug.Log("CHAKVA: The forest feels familiar.");
                break;

            case 3:
                Debug.Log("CHAKVA: Something is following Ishita.");

                if (chudailPlaceholder != null)
                    chudailPlaceholder.SetActive(true);
                break;

            default:
                Debug.Log("CHAKVA: The forest refuses to let Ishita leave.");
                break;
        }

        Debug.Log("Chakva: loop " + loopCount);
    }
}
