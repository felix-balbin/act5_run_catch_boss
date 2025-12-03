using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Charge")]
public class ChargeState : BossState
{
    public BossState AttackState;
    public float ChargeSpeed = 10f;
    public float ChargeDuration = 0.7f;

    private float timer;
    private Vector3 dir;

    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;

        var ctx = fsm.GetComponent<EnemyAIContext>();

        ctx.Animator.SetTrigger("Charge");

        dir = (ctx.Target.position - ctx.transform.position).normalized;
    }

    public override void OnUpdate(StateMachine fsm)
    {
        timer += Time.deltaTime;
        var ctx = fsm.GetComponent<EnemyAIContext>();

        ctx.transform.position += dir * ChargeSpeed * Time.deltaTime;

        if (timer >= ChargeDuration)
        {
            fsm.ChangeState(AttackState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
    }
}
