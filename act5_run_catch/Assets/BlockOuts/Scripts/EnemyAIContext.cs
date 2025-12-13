using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIContext : MonoBehaviour
{
    public Transform Target;
    public float SightDistance = 10f;
    public float AttackRange = 2f;
    public float ChargeRange = 4f;

    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public Animator Animator;

    public ShowIndicators Indicators;

    public CameraSwitcher CameraSwitcher;

    void Awake()
    {
        Debug.Log("EnemyAIContext Awake ejecutado");

        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Agent = GetComponent<NavMeshAgent>();

        Vector3 targetPos = Target.position;
        Vector3 bossPos  = Agent.transform.position;
        float dist = Vector3.Distance(bossPos, targetPos);

        if (dist<(SightDistance+5f))
        {
            CameraSwitcher.SwitchCamera();

        }
    }

    public void PlayStep()
    {
        Debug.Log("Step");
    }
    public void ActivateShield()
    {
        Debug.Log("ActivateShield");
    }
    public void StartAttack()
    {
        Debug.Log("StartAttack");
    }
    public void EndAttack()
    {
        Debug.Log("EndAttack");
    }
}
