using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(EnemyAnim))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(CheckStateEnemy))]

public class EnemyBody : Body
{
    public bool isDying;
    public bool isMoving;
    public bool isAttacking;

    public NavMeshAgent navMeshAgent;
    public EnemyAnim enemyAnim;
    public CheckStateEnemy checkStateEnemy;
    public MeleeDealDamage meleeDealDamage;
    public RangeDealDamage rangeDealDamage;
    public EnemyHealth enemyHealth;

    private void Awake()
    {
        if (!enemyAnim)
            enemyAnim = GetComponent<EnemyAnim>();

        if (!navMeshAgent)
            navMeshAgent = GetComponent<NavMeshAgent>();

        if (!enemyHealth)
            enemyHealth = GetComponent<EnemyHealth>();

        if (!checkStateEnemy)
            checkStateEnemy = GetComponent<CheckStateEnemy>();

        if (!meleeDealDamage && GetComponentInChildren<MeleeDealDamage>())
            meleeDealDamage = GetComponentInChildren<MeleeDealDamage>();

        if (!rangeDealDamage && GetComponent<RangeDealDamage>())
            rangeDealDamage = GetComponent<RangeDealDamage>();

        RegisterBody(enemyHealth, false);
    }
}
