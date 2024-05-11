using UnityEngine;
using UnityEngine.Events;

public class CastomButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressed;
    [SerializeField] private UnityEvent _released;

    public virtual void Press()
    {
        _pressed?.Invoke();
    }

    public virtual void Release()
    {
        _released?.Invoke();
    }
}