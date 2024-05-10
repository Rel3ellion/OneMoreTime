using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private float _toAngle;
    public void RotateTo45()
    {
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, _toAngle, 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45f);
    }
}