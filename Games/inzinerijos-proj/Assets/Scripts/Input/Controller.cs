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
    public string portName;
    public int baudRate = 9600;
    public StopBits stopBits = StopBits.One;
    public Parity parity = Parity.None;

    SerialPort serialPort;
    char buffer;

    public override bool Initialize()
    {
        serialPort = new SerialPort();
        serialPort.PortName = portName;
        serialPort.BaudRate = baudRate;
        serialPort.StopBits = stopBits;
        serialPort.Parity = parity;
        serialPort.Open();
        return true;
    }
    public override bool TiltUp
    {
        get
        {
            while (serialPort.BytesToRead > 0)
            {
                buffer = Convert.ToChar(serialPort.ReadChar());
            }
            if (buffer == '0')
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

    public static string[] GetPorts()
    {
        return SerialPort.GetPortNames();
    }
}
