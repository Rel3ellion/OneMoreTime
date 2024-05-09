using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class LaserXLock : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private float distanceRay;
    [SerializeField] private float speed;

    public Vector2 vector2;
    private Vector3 dir;


    private void Start()
    {
        point = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        MoveLaser();
    }

    private void MoveLaser()
    {
        dir = new Vector3(dir.x, vector2.x, vector2.y);
        point.transform.Translate(dir.normalized * speed);
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var ray = new Ray(point.position, point.right);

        DrawRay(ray, distanceRay, Color.red);
    }

    private void DrawRay(Ray ray, float distance, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, color);
    }
#endif
}
