using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testInput : MonoBehaviour
{
    public Action PressE;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            PressE?.Invoke();
    }
}
