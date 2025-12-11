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
        //ctx.Animator.CrossFade("Run", 0.1f);
    }

    public override void OnUpdate(StateMachine fsm)
    {
        if (fsm.CurrentState != this) return;

        var ctx = fsm.GetComponent<EnemyAIContext>();

        float dist = Vector3.Distance(ctx.transform.position, ctx.Target.position);

        if (!ctx.Agent.hasPath)
        {
            ctx.Agent.SetDestination(ctx.Target.position);
        }
        else
        {
            ctx.Agent.destination = ctx.Target.position;
        }

        //Si la distancia entre el boss y el target es menor a la distancia para activar el charge, activa el telégrafo
        if (dist <= ctx.ChargeRange)
        {
            fsm.ChangeState(ChargeTelegraphState);
        }

        //ctx.Animator.SetBool("Run", ctx.Agent.velocity.magnitude > 0.1f);
    }

    public override void OnExit(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Animator.SetBool("Run", false);
    }
}
