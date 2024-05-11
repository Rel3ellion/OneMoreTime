using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LaserVisual : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float defoultLeng = 10;

    LineRenderer lineRenderer;
    RaycastHit raycastHit;
    Vector3 Vector = Vector3.zero;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Laser();
    }

    private void Laser()
    {
        lineRenderer.SetPosition(0, Vector);

        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, defoultLeng, layerMask))
        {
            lineRenderer.SetPosition(1, new Vector3 (raycastHit.point.x, 0,raycastHit.point.z));
        }
        else
        {
            lineRenderer.SetPosition(1, Vector);
        }
    }
}