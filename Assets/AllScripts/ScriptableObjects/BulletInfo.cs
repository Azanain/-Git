using UnityEngine;

[CreateAssetMenu]
public class BulletInfo : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeLife;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private UnitInfo _unitInfo;

    public float moveSpeed => _moveSpeed;
    public float timeLife => _timeLife;
    public float damage => _damage;
    public ParticleSystem particle => _particle;
    public AudioClip audioClip => _audioClip;
    public UnitInfo unitInfo => _unitInfo;
}
