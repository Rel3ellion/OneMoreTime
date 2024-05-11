using System.Collections;
using UnityEngine;

public class ButtonShaderController : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Material _currentMaterial;

    private void Start()
    {
        _meshRenderer.material = new Material(_material);
        _currentMaterial = _meshRenderer.material;
    }

    public void SetPressed(bool isPressed)
    {
        if (isPressed)
        {
            _currentMaterial.SetInt("_IsPressed", 1);
        }
        else
        {
            _currentMaterial.SetInt("_IsPressed", 0);
        }
    }

    public void SetError(bool isError)
    {
        if (isError)
        {
            _currentMaterial.SetInt("_IsError", 1);
        }
        else
        {
            _currentMaterial.SetInt("_IsError", 0);
        }
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            _currentMaterial.SetInt("_IsEnambled", 1);
        }
        else
        {
            _currentMaterial.SetInt("_IsEnambled", 0);
        }
    }

    public void SetDefault()
    {
        SetError(false);
        SetPressed(false);
    }
}
