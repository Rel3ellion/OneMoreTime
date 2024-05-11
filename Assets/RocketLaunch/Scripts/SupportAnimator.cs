using UnityEngine;

public class SupportAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Open()
    {
        _animator.SetTrigger("Open");
    }
}
