using UnityEngine;
[CreateAssetMenu]
public class IdleState : State
{
    public override void Init()
    {
        base.Init();
        body.isMoving = false;
        body.audioManager.StopSoundStep();
        body.navMeshAgent.velocity = Vector3.zero;
        body.enemyAnim.IdleAnim();
    }
    public override void Run()
    {
        if (body.checkStateEnemy.DistanceToPlayer < body.unitInfo.rangeVision)
            body.transform.LookAt(body.checkStateEnemy.PlayerTransform.position);
    }
}
