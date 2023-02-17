using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _maxSizeSphere;
    [SerializeField] private SphereCollider _sphereCollider;

    private void Awake()
    {
        if (!_sphereCollider)
            _sphereCollider = GetComponent<SphereCollider>();
    }
    public void StartExplosion(string tagTarget, float damage, float duration, float maxSise)
    {
        _tagTarget = tagTarget;
        _damage = damage;
        _duration = duration;
        _maxSizeSphere = maxSise;

        StartCoroutine(TimerExplosion());
    }
    private IEnumerator TimerExplosion()
    {
        float progress = 0;
        float timer = 0;
        float size = 0;
        _sphereCollider.radius = 0;
        transform.localScale = Vector3.zero;

        while (timer < _duration)
        {
            timer += Time.deltaTime;

            progress = timer / _duration;
            size = progress * _maxSizeSphere;

            transform.localScale = new Vector3(size, size, size);
            _sphereCollider.radius = size;
            yield return null;
        }
        if (timer >= _duration)
        { 
            StopCoroutine(TimerExplosion());
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagTarget))
        {
            Health healthBodyPlayer = DataUnits.GetBody(other.transform.root.name);
            healthBodyPlayer.TakeDamage(_damage);
        }
    }
}
