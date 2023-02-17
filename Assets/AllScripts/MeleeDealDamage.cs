using UnityEngine;

public class MeleeDealDamage : MonoBehaviour
{
    [SerializeField] private Body _body;
    private void Start()
    {
        if (!_body)
            _body = GetComponentInParent<Body>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_body.unitInfo.tagTarget))
        {
            Health healthBody = DataUnits.GetBody(other.transform.root.name);
            healthBody.TakeDamage(_body.unitInfo.damage);
        }
    }
}
