using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public GameInput ard;

    private void Start()
    {
        foreach (var item in SerialPort.GetPortNames())
        {
            //Debug.Log(item);
        }
        ard.Initialize();
    }

    private void Update()
    {
        Debug.Log(ard.TiltUp);
    }
}
