using UnityEngine;

public class KeepAlive : MonoBehaviour
{
    private static KeepAlive instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
