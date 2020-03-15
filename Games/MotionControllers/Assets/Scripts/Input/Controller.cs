using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Controller", menuName = "Input/Controller")]
public class Controller : GameInput
{
    [SerializeField]
    string portName;

    SerialPort serialPort;
    int counter = 0;

    public override bool Initialize()
    {
        serialPort = new SerialPort();
        serialPort.BaudRate = 9600;
        serialPort.PortName = portName; // Set in Windows
        serialPort.Open();
        return true;
    }
    public override bool TiltUp
    {
        get
        {
            string buffer = "";
            while (serialPort.BytesToRead > 0)
            {
                buffer += Convert.ToChar(serialPort.ReadChar());
            }
            if(buffer == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public override bool Button
    {
        get
        {
            /// Runs code required to get button state from arduino controller
            /// and parses it into a boolean variable then returns it
            throw new NotImplementedException();
        }
    }
}
