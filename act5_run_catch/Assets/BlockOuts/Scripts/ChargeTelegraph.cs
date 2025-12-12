using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "FSM/States/ChargeTelegraph")]
public class ChargeTelegraphState : BossState
{
    public BossState ChargeState;
    public float TelegraphDuration = 1.5f;

    //range marcado
    //public Image ability2Image;
    //public Canvas ability2Canvas;
    //public Image ability2RangeIndicator;


    // salto dotween
    public float JumpHigh = 2f;
    public float JumpDuration = 0.5f;
    public int JumpsNum = 1;

    //public TrailRenderer TrailRenderer;

    private Tween tween;

    private float timer;

    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;

        //ability2Canvas.enabled = true;
        //ability2Image.enabled = true;
        //ability2RangeIndicator.enabled = true;


        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Agent.isStopped = true;
        ctx.Animator.SetTrigger("Telegraph");
        JumpTween(ctx);
    }

    private void JumpTween(EnemyAIContext ctx)
    {
        Vector3 dir = (ctx.Target.position - ctx.transform.position).normalized;
        Vector3 jumpTarget = ctx.transform.position + (dir * 3f);
        //TrailRenderer.emitting = true;

        tween = ctx.transform.DOJump(
            jumpTarget, // Mantener posición XZ
            JumpHigh,               // Altura del salto
            JumpsNum,                 // Número de saltos
            JumpDuration             // Duración
        ).SetEase(Ease.OutQuad);

    }

    public override void OnUpdate(StateMachine fsm)
    {        
        timer += Time.deltaTime;

        //si el jugador pasa el rato suficiente dentro de la zona de ataque
        //(ojo, no la de detección), pasa a cargar el ataque
        if (timer >= TelegraphDuration)
        {
            fsm.ChangeState(ChargeState);
        }
    }

    public override void OnExit(StateMachine fsm)
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill(); // Detener la animación DOTween
        }


        //ability2Canvas.enabled = false;
        //ability2Image.enabled = false;
        //ability2RangeIndicator.enabled = false;
    }
}
