using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminalLamp : MonoBehaviour
{
    [SerializeField] private MeshRenderer _rederer;
    [SerializeField] private Material _materialOff;
    [SerializeField] private Material _materialOn;

    public bool IsOn { get; private set; } = false;

    private void Start()
    {
        SetOff();
    }

    public void SetOn()
    {
        IsOn = true;
        _rederer.material = _materialOn;
    }

    public void SetOff()
    {
        IsOn = false;
        _rederer.material = _materialOff;
    }
}
