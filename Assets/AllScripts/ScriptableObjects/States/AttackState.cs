using System.Collections;
using UnityEngine;
[CreateAssetMenu]
public class AttackState : State
{
    private Coroutine _routine;
    public override void Init()
    {
        base.Init();
        body.isMoving = false;
        body.isAttacking = false;
        body.navMeshAgent.SetDestination(body.transform.position);
    }
    public override void Run()
    {
        Vector3 direction = body.checkStateEnemy.PlayerTransform.position - body.transform.position;
        Quaternion rotaion = Quaternion.LookRotation(direction);
        body.transform.rotation = Quaternion.Lerp(body.transform.rotation, rotaion, body.unitInfo.rotateSpeed * Time.deltaTime);

        if (!body.isAttacking)
        {
            _routine = Coroutines.StartRoutine(ReloadAttack());
            body.enemyAnim.StartAttackAnim();
        }
        //else
        //    body.enemyAnim.StopAttackAnimEvent();
        //   // body.enemyAnim.IdleAnim();
    }
    private IEnumerator ReloadAttack()
    {
        body.enemyAnim.StopAttackAnimEvent();
        body.isAttacking = true;
        yield return new WaitForSeconds(body.unitInfo.rangeAttack);
        body.isAttacking = false;
        Coroutines.StopRoutine(_routine);
    }
}
