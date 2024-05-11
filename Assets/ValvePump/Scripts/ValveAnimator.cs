using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Activate()
    {
        _animator.SetBool("IsOn", true);
    }
}
