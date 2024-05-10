using System.Collections;
using UnityEngine;

public class CastomServerButton : CastomButton
{
    [SerializeField] private MathQuestion _mathQuest;
    [SerializeField] private ButtonShaderController _shaderController;
    [SerializeField, Range (0,9)] private int _answer;
    [SerializeField] private float _buttonDelay;

    private Coroutine _coroutine = null;
    private bool _isEnable = false;

    public void Activate()
    {
        _isEnable = true;
        _shaderController.SetActive(true);
    }

    public void Deactivate()
    {
        _isEnable = false;
        _shaderController.SetActive(false);
    }

    public override void Press()
    {
        if (_isEnable == false)
        {
            return;
        }

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
        var wait = new WaitForSeconds(_buttonDelay);

        yield return wait;

        _shaderController.SetDefault();
        _coroutine = null;
    }
}
