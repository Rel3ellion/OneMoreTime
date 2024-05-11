using UnityEngine;
using UnityEngine.Events;

public class TumblerTerminal : MonoBehaviour
{
    [SerializeField] private TumblerAnimator _animator;
    [SerializeField] private MainTerminalLamp _firstLamp;
    [SerializeField] private MainTerminalLamp _secondLamp;
    [SerializeField] private UnityEvent _tumblerActivated;

    private bool _isActive = false;

    public void ActivateFirstLamp()
    {
        _firstLamp.SetOn();
        CheckStatus();
    }

    public void ActivateSecondLamp()
    {
        _secondLamp.SetOn();
        CheckStatus();
    }

    public void Activate()
    {
        if (_isActive == false)
        {
            return;
        }

        _animator.SetOn();
        _tumblerActivated?.Invoke();
    }

    private void CheckStatus()
    {
        if (_firstLamp.IsOn && _secondLamp.IsOn)
        {
            _isActive = true;
        }
    }
}
