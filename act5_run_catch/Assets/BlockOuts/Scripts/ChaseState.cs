using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Chase")]
public class ChaseState : BossState
{
    public BossState ChargeTelegraphState;
    public BossState AttackState;

    public override void OnEnter(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Agent.isStopped = false;
        ctx.Animator.SetBool("Run", true);
    }

    public override void OnUpdate(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();

        float dist = Vector3.Distance(ctx.transform.position, ctx.Target.position);

        ctx.Agent.SetDestination(ctx.Target.position);

        if (dist <= ctx.ChargeRange)
        {
            fsm.ChangeState(ChargeTelegraphState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Animator.SetBool("Run", false);
    }
}
