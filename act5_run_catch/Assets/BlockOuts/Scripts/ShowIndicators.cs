using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowIndicators : MonoBehaviour
{
    public Animator Animator;

    //flecha
    public Canvas ability1Canvas;
    public Image ability1Skillshot;

    //range marcado
    public Canvas ability2Canvas;
    public Image ability2RangeIndicator;

    //ataque
    public Canvas ability3Canvas;
    public Image ability3Alert;

    void Awake()
    {
        ShowRange(false);
        ShowSkillshot(false);
        ShowAlert(false);

    }

    public void ShowRange(bool status)
    {
        ability2Canvas.enabled = status;
        ability2RangeIndicator.enabled = status;
    }

    public void ShowSkillshot(bool status)
    {
        ability1Canvas.enabled = status;
        ability1Skillshot.enabled = status;
    }
    public void ShowAlert(bool status)
    {
        ability3Canvas.enabled = status;
        ability3Alert.enabled = status;
    }

    public void RotateSkillshotTo(Vector3 targetDir)
    {
        float angle = Mathf.Atan2(targetDir.x, targetDir.z) * Mathf.Rad2Deg;

        ability1Skillshot.rectTransform.rotation = Quaternion.Euler(90, 0, -angle);
    }
}
