using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMirror : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private float distanceRay = 40f;
    [SerializeField] private Color color;

    [Header("debug")]
    public bool isRay = false;
    private bool isCor = true;
    [SerializeField] private LineRenderer line;

    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        if (isRay)
        {
            var ray = new Ray(point.transform.position, point.transform.right);
            line.enabled = true;

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                var hitCollider = hitInfo.collider;

                if (hitCollider.TryGetComponent(out FinishMirror mir))
                {
                    mir.isLaser1 = true;
                }

                if (hitCollider.TryGetComponent(out RaycastMirror miror))
                {
                    miror.isRay = true;
                    Debug.Log("isRay true");
                }
                
                

            }

            if(isCor)
            {
                StartCoroutine(DefaultIsRay(1f));
                isCor = false;
            }
            
        }
        else
        {
            line.enabled = false;
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
            var ray = new Ray(point.transform.position, point.transform.right);
            Debug.DrawRay(point.transform.position, point.transform.right * distanceRay, color);
        }
    }
#endif
}
