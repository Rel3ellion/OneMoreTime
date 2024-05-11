using System;
using UnityEngine;
using UnityEngine.Events;

public class ValvePump : MonoBehaviour
{
    [SerializeField] private ValveAnimator _animator;
    [Space]
    [SerializeField] private UnityEvent _valveActivated;

    public event Action Complited;

    public bool IsDone { get; private set; } = false;

    public void Activate()
    {
        _animator.Activate();
        _valveActivated?.Invoke();
        IsDone = true;
        Complited?.Invoke();
        Debug.Log($"Valve was open = {IsDone}");
    }
}
