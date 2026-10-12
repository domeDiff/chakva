using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string objectName = "Object";
    [SerializeField] private string interactionMessage = "you examined the object";

    public void Interact()
    {
        Debug.Log(objectName + ": " + interactionMessage);
    }
}
