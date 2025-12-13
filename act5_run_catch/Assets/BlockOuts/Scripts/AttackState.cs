using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "FSM/States/Attack")]
public class AttackState : BossState
{
    public BossState IdleState;
    public float AttackDuration = 1f;
    private float timer;
    //private Vector3 dir;
    //public float ChargeSpeed = 10f;



    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;
        var ctx = fsm.GetComponent<EnemyAIContext>();

        ctx.Agent.isStopped = true;
        ctx.Animator.SetTrigger("Attack");

        ctx.Indicators.ShowAlert(true);

    }

    public override void OnUpdate(StateMachine fsm)
    {
        timer += Time.deltaTime;

        if (timer > AttackDuration)
        {
            //var ctx = fsm.GetComponent<EnemyAIContext>();
            //ctx.transform.position += dir * ChargeSpeed * Time.deltaTime;
            fsm.ChangeState(IdleState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Indicators.ShowAlert(false);

    }
}
