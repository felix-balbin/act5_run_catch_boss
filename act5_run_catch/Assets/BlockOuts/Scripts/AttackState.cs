using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Attack")]
public class AttackState : BossState
{
    public BossState IdleState;
    public float AttackDuration = 1f;
    private float timer;

    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;
        var ctx = fsm.GetComponent<EnemyAIContext>();

        ctx.Agent.isStopped = true;
        ctx.Animator.SetTrigger("Attack");
    }

    public override void OnUpdate(StateMachine fsm)
    {
        timer += Time.deltaTime;

        if (timer > AttackDuration)
        {
            fsm.ChangeState(IdleState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
    }
}
