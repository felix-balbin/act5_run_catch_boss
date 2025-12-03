using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Idle")]
public class IdleState : BossState
{
    public BossState ChaseState;

    public override void OnEnter(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Agent.isStopped = true;
        ctx.Animator.SetBool("Idle", true);
    }

    public override void OnUpdate(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();

        float dist = Vector3.Distance(ctx.transform.position, ctx.Target.position);

        if (dist < ctx.SightDistance)
        {
            fsm.ChangeState(ChaseState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Animator.SetBool("Idle", false);
    }
}
