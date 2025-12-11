using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Idle")]
public class IdleState : BossState
{
    public BossState ChaseState;

    public override void OnEnter(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Agent.ResetPath();
        ctx.Agent.isStopped = true;
        ctx.Animator.SetBool("Idle", true);
    }

    public override void OnUpdate(StateMachine fsm)
    {
        if (fsm.CurrentState != this) return;

        var ctx = fsm.GetComponent<EnemyAIContext>();

        float dist = Vector3.Distance(ctx.transform.position, ctx.Target.position);

        //Si la distancia entre el target y el boss es menor que la distancia de vista,
        //lo detecta y entra al estado de chase
        if (dist < ctx.SightDistance-1f)
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
