using UnityEngine;
[CreateAssetMenu]
public class UnitInfo : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rateAttack;
    [SerializeField] private float _rangeVision;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _damage;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private uint _rewardExp;
    [SerializeField] private LayerMask _targetLayer;
    public string id => _id;
    public float maxHp => _maxHp;
    public float moveSpeed => _moveSpeed;
    public float rateAttack => _rateAttack;
    public float rangeVision => _rangeVision;
    public float rangeAttack => _rangeAttack;
    public float damage => _damage;
    public float rotateSpeed => _rotateSpeed;
    public string tagTarget => _tagTarget;
    public uint rewardExp => _rewardExp;
    public LayerMask targetLayer => _targetLayer;
}
