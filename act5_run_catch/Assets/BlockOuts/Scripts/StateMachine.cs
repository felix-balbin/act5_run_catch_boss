using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BossState CurrentState;

    void Start()
    {
        CurrentState?.OnEnter(this);
    }

    void Update()
    {
        CurrentState?.OnUpdate(this);
    }

    public void ChangeState(BossState newState)
    {
        if (newState == CurrentState) return;

        CurrentState?.OnExit(this);
        CurrentState = newState;
        CurrentState?.OnEnter(this);
    }
}
