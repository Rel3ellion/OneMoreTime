using UnityEngine;

public class Support : MonoBehaviour
{
    [SerializeField] private SupportAnimator _animator;

    public void Open()
    {
        _animator.Open();
    }
}
