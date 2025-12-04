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

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
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
