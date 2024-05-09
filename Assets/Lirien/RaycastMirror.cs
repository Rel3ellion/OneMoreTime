using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMirror : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private float distanceRay = 40f;

    [Header("debug")]
    public bool isRay = false;
    private bool isCor = true;


    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        if (isRay)
        {
            var ray = new Ray(point.position, point.right);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                var hitCollider = hitInfo.collider;

                if (hitCollider.TryGetComponent(out RaycastMirror miror))
                {
                    miror.isRay = true;
                }
            }

            if(isCor)
            {
                StartCoroutine(DefaultIsRay(1f));
                isCor = false;
            }
            
        }
    }

    IEnumerator DefaultIsRay(float value)
    {
        yield return new WaitForSeconds(value);
        isRay = false;
        isCor = true;
    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (isRay)
        {
            var ray = new Ray(point.position, point.right);
            Debug.DrawRay(point.position, point.right * distanceRay, Color.red);
        }
    }
#endif
}
