using System.Collections;
using UnityEngine;
public enum EnemyStates { Idle = 1, Move = 2, Attack = 3, Death = 4 }
public class CheckStateEnemy : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _timeCheckState;
    [SerializeField] private EnemyBody _enemyBody;
    public Transform PlayerTransform { get; private set; }
    public float DistanceToPlayer { get; private set; }

    [Header("States")]
    public State CurrentState;
    public State IdleState;
    public State MoveSate;
    public State AttackState;
    public State DeathState;

    public void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform)
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (!_enemyBody && GetComponent<EnemyBody>())
            _enemyBody = GetComponent<EnemyBody>();

        if(_enemyBody.meleeDealDamage)
            _enemyBody.meleeDealDamage.enabled = false;

        StartCoroutine(CheckingState());
    }
    public void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.body = _enemyBody;
        CurrentState.Init();
    }
    public void CheckAction(EnemyStates actions)
    {
        switch (actions)
        {
            case EnemyStates.Idle:
                CurrentState = IdleState;
                break;
            case EnemyStates.Move:
                if (_enemyBody.meleeDealDamage)
                    _enemyBody.meleeDealDamage.enabled = false;
                CurrentState = MoveSate;
                break;
            case EnemyStates.Attack:
                if (_enemyBody.meleeDealDamage)
                    _enemyBody.meleeDealDamage.enabled = true;
                CurrentState = AttackState;
                break;
            case EnemyStates.Death:
                CurrentState = DeathState;
                break;

            default:
                break;
        }

        if (_enemyBody.isDying)
            CurrentState = DeathState;

        SetState(CurrentState);
        CurrentState.Run();
    }
    public IEnumerator CheckingState()
    {
        while (true)
        {
            DistanceToPlayer = Vector3.Distance(transform.position, PlayerTransform.position);

            if (DistanceToPlayer <= _enemyBody.unitInfo.rangeVision)
            {
                if (DistanceToPlayer < _enemyBody.unitInfo.rangeAttack)
                    CheckAction(EnemyStates.Attack);
                else
                    CheckAction(EnemyStates.Move);
            }
            else
                CheckAction(EnemyStates.Idle);

            yield return new WaitForSeconds(_timeCheckState);
        }
    }
}
