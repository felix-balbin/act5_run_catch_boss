using UnityEngine;

public abstract class BossState : ScriptableObject
{
    public abstract void OnEnter(StateMachine fsm);
    public abstract void OnUpdate(StateMachine fsm);
    public abstract void OnExit(StateMachine fsm);
}
