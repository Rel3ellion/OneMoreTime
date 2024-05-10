using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _reder;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _materialOn;
    [SerializeField] private Material _materialOff;
    [SerializeField] private Vector2Int _position;

    public event Action<Vector2Int> PanelChanged;

    private bool _isLocked = false;
    private bool _isActive = false;
    private bool _isOn = false;

    public bool Status => _isOn;

    private void Start()
    {
        UpdateMaterial();
    }

    public void Activate()
    {
        _isActive = true;

        UpdateMaterial();
    }

    public void Deactivate()
    {
        _isActive = false;

        UpdateMaterial();
    }

    public void SetStatus(bool isOn)
    {
        _isOn = isOn;

        UpdateMaterial();
    }

    public void SetLockedStatus(bool isLocked)
    {
        _isLocked = isLocked;
    }

    public void SwitchStatus()
    {
        if (_isLocked)
        {
            return;
        }

        if (_isActive == false)
        {
            return;
        }

        _isOn = !_isOn;

        UpdateMaterial();
        PanelChanged?.Invoke(_position);
    }

    private void UpdateMaterial()
    {
        if (_isActive == false)
        {
            _reder.material = _baseMaterial;

            return;
        }

        if (_isOn)
        {
            _reder.material = _materialOn;
        }
        else
        {
            _reder.material = _materialOff;
        }
    }
}
