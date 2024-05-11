using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private float distanceRay;
    [SerializeField] private Color color;
    
    private Timer timer;

    private void Update()
    {
        var ray = new Ray(point.position, point.right);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distanceRay))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out RaycastMirror miror))
            {
                miror.isRay = true;
                
            }
        }
    }



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var ray = new Ray(point.position, point.right);

        Debug.DrawRay(point.position, point.right * distanceRay, color);
    }

#endif
}