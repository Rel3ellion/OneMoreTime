using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMirror : MonoBehaviour
{
    public bool isLaser1 = false;

    public bool IsDone = false;

    private float _randAngle1;
    private float _randAngle2;
    private float _randAngle3;

    private void Start()
    {
        _randAngle1 = UnityEngine.Random.Range(1, 99);
        _randAngle2 = UnityEngine.Random.Range(1, 99);
        _randAngle3 = UnityEngine.Random.Range(1, 99);
    }



    private void Update()
    {
        if(isLaser1)
        {
            Debug.Log("IsLaser1Done");
            IsDone = true;
        }
            

        if (IsDone)
        {
            Activate();
            enabled = false;
        }

        RotateAll();
    }

    public event Action ComplitedLaser;

    public void Activate()
    {
        ComplitedLaser?.Invoke();
    }

    private void RotateAll()
    {
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(_randAngle1, _randAngle2, _randAngle3);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45f);
    }
}
