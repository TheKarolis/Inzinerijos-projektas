using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;

public class ConnectionWizard : MonoBehaviour
{
    [SerializeField]
    GameObject overlay;

    [SerializeField]
    TMP_Dropdown PortSelect;

    [SerializeField]
    TextMeshProUGUI message;

    [SerializeField]
    GameObject loadingIcon;

    private void Update()
    {
        if (ControllerInput.instance.connected)
        {
            overlay.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            if(!Application.isEditor || true)
            {
                overlay.SetActive(true);
                Time.timeScale = 0;
            }
            List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
            foreach (string item in SerialPort.GetPortNames())
            {
                list.Add(new TMP_Dropdown.OptionData(item));
            }
            PortSelect.options = list;
        }
    }

    private void Start()
    {
    }
    void EnableWizard()
    {

    }
    private void DisableWizard()
    {

    }
    public void Connect()
    {
        if (ControllerInput.instance.TryConnection(PortSelect.options[PortSelect.value].text ,ConnectionSuccess, ConnectionFailed))
        {
            message.text = "Trying connection";
            loadingIcon.SetActive(true);
        }
        else
        {
            message.text = "The port does not exist!";
        }
    }
    void ConnectionFailed()
    {
        message.text = "Connection failed : no answer";
        loadingIcon.SetActive(false);
    }
    void ConnectionSuccess(ControllerInput.ControllerType sensor)
    {
        switch (sensor)
        {
            case ControllerInput.ControllerType.Tilt:
                message.text = "Connection success : Sensor (Tilt)";
                break;
            case ControllerInput.ControllerType.Jump:
                message.text = "Connection success : Sensor (Jump)";
                break;
            case ControllerInput.ControllerType.Undefined:
                message.text = "Connection failed : Unsupported sensor.";
                break;
        }
        loadingIcon.SetActive(false);
    }
}
