using UnityEngine;
[RequireComponent(typeof(Pool))]
public class RangeDealDamage : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private EnemyBody _enemyBody;
    [SerializeField] private Transform _firePosition;
    private void Awake()
    {
        if (!_pool)
            _pool = GetComponent<Pool>();
        if (!_firePosition)
            _firePosition = transform.Find("FirePosition");
        if (!_enemyBody)
            _enemyBody = GetComponent<EnemyBody>();
    }
    private void ShotAnimEvent()
    {
        var bullet = _pool.GetFreeElement(_firePosition.position, _firePosition.rotation);
        if (bullet.GetComponent<BallisticBullet>())
        { 
            var ballisticbullet =  bullet.GetComponent<BallisticBullet>();
            ballisticbullet.StartFindingTarget(_enemyBody.checkStateEnemy.PlayerTransform);
        }
    }
}
