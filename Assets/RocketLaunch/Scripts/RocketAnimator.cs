using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Launch()
    {
        _animator.SetTrigger("Launch");
    }
}
