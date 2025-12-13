using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    //[SerializeField] private Animator animator;
    public float bossCameraDuration = 3f;
    public CinemachineCamera mainCam;
    public CinemachineCamera bossCam;
    private bool bossCamActive;
    private float timer;



    // Update is called once per frame
    void Update()
    {
        if (!bossCamActive) return;
        timer += Time.deltaTime;

        if (timer > bossCameraDuration)
        {
            //ActivateBossCam(false);
            DeactivateBossCam();
        }
    }

    public void ActivateBossCam()
    {
        if (bossCamActive) return;

        bossCamActive = true;
        timer = 0f;
        mainCam.Priority = 0;
        bossCam.Priority = 10;
    }


    public void DeactivateBossCam()
    {
        bossCamActive = false;
        mainCam.Priority = 10;
        bossCam.Priority = 0;
    }

    //public void ActivateBossCam(bool state)
    //{
    //    if (state)
    //    {
    //        if (bossCamActive) return;

    //        bossCamActive = true;
    //        timer = 0f;
    //        mainCam.Priority = 0;
    //        bossCam.Priority = 10;
    //    }
    //    else
    //    {
    //        bossCamActive = false;
    //        mainCam.Priority = 10;
    //        bossCam.Priority = 0;
    //    }
    //}

}

    //    [SerializeField]private Animator animator;
    //    private StateMachine StateMachine;
    //    private bool mainCamera = true;

    //    private void Awake()
    //    {
    //        animator = GetComponent<Animator>();
    //    }

    //    public void SwitchCamera()
    //    {
    //        //animator.Play(state);
    //        if (mainCamera)
    //        {
    //            animator.Play("MainCameraState");
    //        }
    //        else
    //        {
    //            animator.Play("BossCameraState");
    //        }
    //        mainCamera = !mainCamera;


    //    }
    //    void Start()
    //    {
    //        SwitchCamera();

    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }
//}
