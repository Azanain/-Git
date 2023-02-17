using UnityEngine;
[CreateAssetMenu]
public class MoveState : State
{
    public override void Init()
    {
        base.Init();
        body.navMeshAgent.speed = body.unitInfo.moveSpeed;
        body.isMoving = true;
        body.enemyAnim.StopAttackAnimEvent();
        body.enemyAnim.MoveAnim();
    }
    public override void Run()
    {
        body.navMeshAgent.SetDestination(body.checkStateEnemy.PlayerTransform.position);
        body.transform.LookAt(body.checkStateEnemy.PlayerTransform.position);
    }
}
