using UnityEngine;

public class ResetButtn : MonoBehaviour
{
    [SerializeField] private MeshRenderer _redrer;
    [SerializeField] private Material _materialOn;
    [SerializeField] private Material _materialOff;

    private void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        _redrer.material = _materialOn;
    }

    public void Deactivate()
    {
        _redrer.material = _materialOff;
    }
}
