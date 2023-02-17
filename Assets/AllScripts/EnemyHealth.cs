using UnityEngine;
public class EnemyHealth : Health
{
    [SerializeField] private EnemyBody _enemyBody;
    private void Start()
    {
        if (!_enemyBody && GetComponent<EnemyBody>())
            _enemyBody = GetComponent<EnemyBody>();

        GetDataInStart(_enemyBody);
    }
    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
        _enemyBody.audioManager.SoundHit();
        _enemyBody.checkStateEnemy.CheckAction(EnemyStates.Death);
    }
    public override void Death()
    {
        _enemyBody.checkStateEnemy.CheckAction(EnemyStates.Death);
    }
    private void DeathAnimEvent()
    {
        EventManager.GainExp(_enemyBody.unitInfo.rewardExp);
        Destroy(gameObject);
    }
}
