using System.Collections;
using UnityEngine;
public class SystemInputCharacter : MonoBehaviour
{
    [SerializeField] private PlayerBody _playerBody;
    [SerializeField] private Camera _camera;
    [SerializeField] private InputInfo inputInfo;
    public Transform _firePosition;
    private bool _isReloading;
    public Vector3 PositionLookAt{ get; private set; }
    private void Awake()
    {
        if(!_playerBody)
            _playerBody = GetComponent<PlayerBody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _playerBody.playerAnim.animator.SetFloat("Speed", v);
        _playerBody.playerAnim.animator.SetFloat("Direction", h);

        if (Input.GetKey(inputInfo.shot))
            _playerBody.playerAnim.ShootAnim(true);
        else
            _playerBody.playerAnim.ShootAnim(false);

        if (Input.GetKey(inputInfo.movingRight))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), _playerBody.unitInfo.rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(inputInfo.movingLeft))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -45, 0), _playerBody.unitInfo.rotateSpeed * Time.deltaTime);
        else
        { 
             Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                PositionLookAt = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
            }
        }

        if (h < .1f && v < .1f)
            _playerBody.audioManager.StopSoundStep();
    }

    private void ShootAnimEvent()
    {
        if (!_isReloading)
        {
            _playerBody.pool.GetFreeElement(_firePosition.position, _firePosition.rotation);
            StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_playerBody.unitInfo.rateAttack);
        _isReloading = false;
        StopCoroutine(Reload());
    }
}
