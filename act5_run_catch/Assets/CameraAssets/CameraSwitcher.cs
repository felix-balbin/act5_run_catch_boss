using UnityEditor;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]private Animator animator;
    private StateMachine StateMachine;
    private bool mainCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchCamera()
    {
        //animator.Play(state);
        if (mainCamera)
        {
            animator.Play("MainCameraState");
        }
        else
        {
            animator.Play("BossCameraState");
        }
        mainCamera = !mainCamera;


    }
    void Start()
    {
        SwitchCamera();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
