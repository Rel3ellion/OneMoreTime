using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RaycastFace : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    Ray ray;

    private bool isMouseDown = false;


    private void FixedUpdate()
    {
        ray = _camera.ScreenPointToRay(Ray_start_position);
        
    }

    private void Update()
    {
        OnMouseEnter();
        //OnMouseExit();

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
    }

    private void OnMouseEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                var hitCollider = hitInfo.collider;

                if (hitCollider.TryGetComponent(out CastomButton button))
                {
                    button.Press();
                    Debug.Log(hitCollider);
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (isMouseDown == false)
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                var hitCollider = hitInfo.collider;

                if (hitCollider.TryGetComponent(out CastomButton button))
                {
                    button.Release();
                    Debug.Log("stop");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin, ray.direction);
    }
}
