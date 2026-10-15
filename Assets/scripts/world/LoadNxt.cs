using Unity.VisualScripting;
using UnityEngine;

public class LoadNxt : MonoBehaviour
{

    [SerializeField] private GameObject chunk;
    [SerializeField] private GameObject chunk_unload;
   // [SerializeField] private Transform player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chunk.SetActive(true);
            chunk_unload.SetActive(false);
        } 
    }
}
