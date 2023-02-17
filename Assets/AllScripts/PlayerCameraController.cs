using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float y, z;

    private void LateUpdate()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y + y, _playerTransform.position.z + z);
    }
}
