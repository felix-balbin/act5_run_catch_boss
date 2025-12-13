using System;
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

    public BossCamera BossCamera;
    public CameraSwitcher CameraSwitcher;
    private bool bossCamTrigger;

    void Awake()
    {
        Debug.Log("EnemyAIContext Awake ejecutado");

        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        BossCamera.CameraBoss();
        //if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

        //Vector3 targetPos = Target.position;
        //Vector3 bossPos  = Agent.transform.position;
        //float dist = Vector3.Distance(bossPos, targetPos);

        //if (!bossCamTrigger && dist <= (SightDistance + 10f))
        //{
        //    bossCamTrigger = true;
        //    CameraSwitcher.ActivateBossCam();

        //}
        
        //if(dist > SightDistance + 13f)
        //{
        //    bossCamTrigger = false;
        //}
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
