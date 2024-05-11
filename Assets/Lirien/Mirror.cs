using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private float _toAngle;
    [SerializeField] private bool _isRotate = false;

    private float _randAngle1;
    private float _randAngle2;
    private float _randAngle3;

    private void Start()
    {
        _randAngle1 = Random.Range(1, 99);
        _randAngle2 = Random.Range(1, 99);
        _randAngle3 = Random.Range(1, 99);
    }

    private void Update()
    {
        if(_isRotate)
        {
            RotateAll();
        }
    }

    public void RotateTo45()
    {
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, _toAngle, 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45f);
    }

    private void RotateAll()
    {
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(_randAngle1, _randAngle2, _randAngle3);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45f);
    }
}