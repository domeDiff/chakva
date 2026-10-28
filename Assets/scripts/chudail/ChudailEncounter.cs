using UnityEngine;

public class ChudailEncounter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerCamera;
    [SerializeField] float footLookAngle = 35f;
    [SerializeField] private float disappearDistance = 4f;


    private void Update()
    {
        if (player == null || playerCamera == null)
            return;

        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= disappearDistance && IsLookingAtFeet())
        {
            Debug.Log("has vanished");

            gameObject.SetActive(false);
        }
    }

    private bool IsLookingAtFeet()
    {
        Vector3 feetPosition = transform.position - Vector3.up;

        Vector3 direction = (feetPosition - playerCamera.position).normalized;

        float angle = Vector3.Angle(playerCamera.forward, direction);

        return angle <= footLookAngle;
    }
}
