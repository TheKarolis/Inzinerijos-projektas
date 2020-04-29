using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using TMPro;

public class ControllerInput : MonoBehaviour
{
    public static bool jump { get; private set; }
    public static bool tilt { get; private set; }
    public static bool button { get; private set; }

    public static string buffer { get; private set; }

    SerialPort jumpSensor;
    SerialPort tiltSensor;

    public bool connected = false;

    public Action onConnectFail;
    public Action onConnectSuccess;
    public Action onDisconect;

    public static ControllerInput instance;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool Connect(string port1, string port2)
    {
        try
        {
            jumpSensor = new SerialPort();
            tiltSensor = new SerialPort();
            jumpSensor.BaudRate = 9600;
            tiltSensor.BaudRate = 9600;
            jumpSensor.PortName = port1;
            tiltSensor.PortName = port2;
            jumpSensor.Open();
            tiltSensor.Open();

            connected = true;
            onConnectSuccess?.Invoke();
            return true;
        }
        catch
        {
            onConnectFail?.Invoke();
            return false;
        }
    }
    void UpdateBuffer()
    {
        buffer = "";
        while (jumpSensor.BytesToRead > 0)
        {
            buffer += Convert.ToChar(jumpSensor.ReadChar());
        }
        while (tiltSensor.BytesToRead > 0)
        {
            buffer += Convert.ToChar(tiltSensor.ReadChar());
        }
        
    }
    void Update()
    {
        if(jumpSensor != null && tiltSensor != null && jumpSensor.IsOpen && tiltSensor.IsOpen)
        {
            UpdateBuffer();
        }
        else if(connected)
        {
            connected = false;
            onDisconect?.Invoke();
        }
    }
}
