using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CastomButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressed;
    [SerializeField] private UnityEvent _released;

    public void Press()
    {
        _pressed?.Invoke();
    }

    public void Release()
    {
        _released?.Invoke();
    }
}
