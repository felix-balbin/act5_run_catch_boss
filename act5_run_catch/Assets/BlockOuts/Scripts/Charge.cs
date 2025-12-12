using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/States/Charge")]
public class ChargeState : BossState
{
    public BossState AttackState;
    public float ChargeSpeed = 5f;
    //public float ChargeDuration = 0.7f; //maxchargedistance
    public float MaxChargeDistance = 6f; //maxchargedistance
    public float WaitingTime = 0.4f;

    private float timer;
    private Vector3 dir;
    private Vector3 targetDash;



    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;

        var ctx = fsm.GetComponent<EnemyAIContext>();

        ctx.Animator.SetTrigger("Charge");

        dir = (ctx.Target.position - ctx.transform.position).normalized;

        //indicator
        ctx.Indicators.ShowSkillshot(true);
        ctx.Indicators.RotateSkillshotTo(dir);

        targetDash = ctx.transform.position + dir * MaxChargeDistance;

    }

    public override void OnUpdate(StateMachine fsm)
    {
        timer += Time.deltaTime;
        var ctx = fsm.GetComponent<EnemyAIContext>();

        if (timer < WaitingTime) return;
        ////mover el boss al 
        //ctx.transform.position += dir * ChargeSpeed * Time.deltaTime;

        ctx.transform.position = Vector3.MoveTowards(ctx.transform.position, targetDash, ChargeSpeed * Time.deltaTime);

        //Si pasa el tiempo de carga, ataca
        //if (timer >= ChargeDuration)
        if(Vector3.Distance(ctx.transform.position, targetDash) < 0.05f)
        {
            fsm.ChangeState(AttackState);

            //ctx.transform.DOPlay();
            //mover el boss al target
        }

    }

    public override void OnExit(StateMachine fsm)
    {
        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Indicators.ShowSkillshot(false);

    }
}
