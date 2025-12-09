using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/ChargeTelegraph")]
public class ChargeTelegraphState : BossState
{
    public BossState ChargeState;
    public float TelegraphDuration = 1.5f;

    private float timer;

    public override void OnEnter(StateMachine fsm)
    {
        timer = 0;

        var ctx = fsm.GetComponent<EnemyAIContext>();
        ctx.Agent.isStopped = true;
        ctx.Animator.SetTrigger("Telegraph");
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
    }
}
