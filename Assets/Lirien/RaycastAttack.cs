using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RaycastAttack : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);


    private void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Ray_start_position);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);

    }
}
