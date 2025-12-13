using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public CameraSwitcher CameraSwitcher;
    private bool bossCamTrigger;
    private EnemyAIContext ctx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        ctx = GetComponent<EnemyAIContext>();
    }
    public void CameraBoss()
    {

        if (!ctx.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

        Vector3 targetPos = ctx.Target.position;
        Vector3 bossPos = ctx.transform.position;
        float dist = Vector3.Distance(bossPos, targetPos);

        if (!bossCamTrigger && dist <= (ctx.SightDistance + 10f))
        {
            bossCamTrigger = true;
            CameraSwitcher.ActivateBossCam();

        }

        if (dist > ctx.SightDistance + 13f)
        {
            bossCamTrigger = false;
        }

    }
}
