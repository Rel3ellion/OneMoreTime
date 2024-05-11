using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static int IsOn = Animator.StringToHash(nameof(IsOn));

    public void SetOn()
    {
        _animator.SetBool(IsOn, true);
    }
}
