using UnityEngine;

public sealed class InstantiateMonobehaviour : MonoBehaviour
{
    public static InstantiateMonobehaviour instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
    }
    public static void InstantiateOject(GameObject gameObject, Transform position, Quaternion rotation)
    {
        Instantiate(gameObject, position.position, rotation);
    }
}
