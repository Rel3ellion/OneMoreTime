using System.Collections;
using UnityEngine;

public class CastomServerButton : CastomButton
{
    [SerializeField] private MathQuestion _mathQuest;
    [SerializeField] private ButtonShaderController _shaderController;
    [SerializeField, Range (0,9)] private int _answer;
    [SerializeField] private float _buttonDelay;

    private bool isPressed = false;
    private Coroutine _coroutine = null;

    private void FixedUpdate()
    {
        if (_coroutine == null)
        {
            return;
        }
    }

    public override void Press()
    {
        if (_coroutine != null)
        {
            return;
        }

        _coroutine = StartCoroutine(ButtonDelayWait());
        _mathQuest.CheckAnsver(_answer, out bool isRight);

        if (isRight)
        {
            _shaderController.SetPressed(true);
        }
        else
        {
            _shaderController.SetError(true);
        }
    }

    public override void Release()
    {
        
    }

    private IEnumerator ButtonDelayWait()
    {
        isPressed = true;
        var wait = new WaitForSeconds(_buttonDelay);

        yield return wait;

        _shaderController.SetDefault();
        _coroutine = null;
    }
}
