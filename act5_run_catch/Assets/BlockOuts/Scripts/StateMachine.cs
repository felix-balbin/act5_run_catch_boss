using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BossState initialState;
    public BossState CurrentState;

    //private float lastStateChangeTime;
    private float timeInCurrentState = 0f;

    [SerializeField] private float stateChangeCooldown = 0.3f;

    void Start()
    {
        if(initialState != null)
        {
            ChangeState(initialState);
        }
        //CurrentState?.OnEnter(this);
    }

    void Update()
    {
        CurrentState?.OnUpdate(this);
        timeInCurrentState += Time.deltaTime;
    }

    public void ChangeState(BossState newState)
    {
        if (newState == CurrentState) return;
        //if (!canChangeState) return;

        if (timeInCurrentState < stateChangeCooldown) return;

        timeInCurrentState = 0f;

        CurrentState?.OnExit(this);

        //BossState previousState = CurrentState;

        CurrentState = newState;

        CurrentState?.OnEnter(this);
    }

    public void ForceChangeState(BossState newState)
    {
        if (newState == CurrentState) return;

        CurrentState?.OnExit(this);
        CurrentState = newState;
        CurrentState?.OnEnter(this);

        //lastStateChangeTime = Time.deltaTime;
    }
}
