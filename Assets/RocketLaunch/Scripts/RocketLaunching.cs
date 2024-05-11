using System.Collections;
using UnityEngine;

public class RocketLaunching : MonoBehaviour
{
    [SerializeField] private RocketAnimator _animator;
    [SerializeField] private float _launchDelay;

    private bool _isStarted = false;

    public void Activate()
    {
        if (_isStarted) return;

        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        var wait = new WaitForSeconds(_launchDelay);

        _isStarted = true;

        yield return wait;

        _animator.Launch();
    }
}
