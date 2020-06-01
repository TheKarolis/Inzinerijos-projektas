using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using TMPro;

public class ControllerInput : MonoBehaviour
{
    public static ControllerInput instance;

    public static bool jump { get; set; }
    public static bool tilt { get; set; }
    public static bool button1 { get; set; }
    public static bool button2 { get; set; }
    
    public static string buffer { get; private set; }

    SerialPort jumpSensor;
    SerialPort tiltSensor;

    int jumpDisconnect = 0;
    int tiltDisconnect = 0;

    public bool connected
    {
        get
        {
            return jumpSensor != null && tiltSensor != null && jumpSensor.IsOpen && tiltSensor.IsOpen;
        }
    }

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

    public Action OnDisconnect;

    protected virtual void Update()
    {
        GetData();
    }

    void GetData()
    {
        if (!connected)
        {
            OnDisconnect?.Invoke();
            return;
        }


        if (jumpSensor != null && jumpSensor.IsOpen && jumpSensor.BytesToRead > 0)
        {
            buffer = Convert.ToString(jumpSensor.ReadChar(), 2);
            while (buffer.Length < 8)
            {
                buffer = '0' + buffer;
            }
            jump = buffer[7] == '1' ? true : false;
        }

        if (tiltSensor != null && tiltSensor.IsOpen && tiltSensor.BytesToRead > 0)
        {
            buffer = Convert.ToString(tiltSensor.ReadChar(), 2);
            while (buffer.Length < 8)
            {
                buffer = '0' + buffer;
            }
            tilt = buffer[5] == '1' ? true : false;
            button1 = buffer[6] == '1' ? true : false;
            button2 = buffer[7] == '1' ? true : false;
        }
    }

    public enum ControllerType { Tilt, Jump, Undefined }
    public bool TryConnection(string portName, Action<ControllerType> OnSuccesss, Action OnFail)
    {
        try
        {
            SerialPort port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = portName;
            port.Open();
            StartCoroutine(ConnectionTest(port, OnSuccesss, OnFail));
            return true;
        }
        catch
        {
            return false;
        }
    }
    IEnumerator ConnectionTest(SerialPort port, Action<ControllerType> OnSuccess, Action OnFail)
    {
        int retries = 5;
        while (retries > 0)
        {
            if (port.BytesToRead > 0)
            {
                string info = Convert.ToString(port.ReadChar(), 2);
                while (info.Length < 8)
                {
                    info = '0' + info;
                }

                switch (info.Substring(1,4))
                {
                    case "1111":
                        tiltSensor = port;
                        OnSuccess?.Invoke(ControllerType.Tilt);
                        break;
                    case "1000":
                        jumpSensor = port;
                        OnSuccess?.Invoke(ControllerType.Jump);
                        break;
                    default:
                        OnSuccess?.Invoke(ControllerType.Undefined);
                        buffer = info;
                        break;
                }
                yield break;
            }
            yield return new WaitForSecondsRealtime(0.5f);
            retries--;
        }
        OnFail?.Invoke();
    }
}
