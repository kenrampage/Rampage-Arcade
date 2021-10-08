using UnityEngine;

public class AnimatorHelper : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string targetParameter;

    public void SetBool(bool value)
    {
        animator.SetBool(targetParameter, value);
    }

    public void SetFloat(float value)
    {
        animator.SetFloat(targetParameter, value);
    }

    public void SetInteger(int value)
    {
        animator.SetInteger(targetParameter, value);
    }

    public void SetTrigger()
    {
        animator.SetTrigger(targetParameter);
    }

}
