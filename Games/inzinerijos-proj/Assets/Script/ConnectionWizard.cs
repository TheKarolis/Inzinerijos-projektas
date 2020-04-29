using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;

public class ConnectionWizard : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI data;

    [SerializeField]
    TMP_Dropdown jumpSensorSelect;
    [SerializeField]
    TMP_Dropdown tiltSensorSelect;

    [SerializeField]
    TextMeshProUGUI message;

    private void Start()
    {
        
    }

    private void Update()
    {
        List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
        foreach (string item in SerialPort.GetPortNames())
        {
            list.Add(new TMP_Dropdown.OptionData(item));
        }
        jumpSensorSelect.options = list;
        tiltSensorSelect.options = list;

        if(ControllerInput.instance.connected)
        {
            data.text = ControllerInput.buffer;
        }
        else
        {
            data.text = "No data...";
        }
    }
    public void Connect()
    {
        if (ControllerInput.instance.Connect(jumpSensorSelect.options[jumpSensorSelect.value].text,
            tiltSensorSelect.options[tiltSensorSelect.value].text))
        {
            message.color = Color.white;
            message.text = "Controllers were connected successufully!";
        }
        else
        {
            message.color = Color.red;
            message.text = "Controllers failed to connect!";
        }
    }

    void Disconnected()
    {

    }
}
