using UnityEngine;
[CreateAssetMenu]
public class DeathState : State
{
    public override void Init()
    {
        base.Init();
        body.isDying = true;
        body.navMeshAgent.velocity = Vector3.zero;
        body.enemyAnim.StopAttackAnimEvent();
        body.enemyAnim.DeathAnim();
    }
    public override void Run()
    {
      
    }
}
