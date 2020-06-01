using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTab : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Inputs;

    [SerializeField]
    TextMeshProUGUI RawData;

    private void Update()
    {
        Inputs.text = string.Format($"" +
            $"[Jump : {ControllerInput.jump}] " +
            $"[Tilt : {ControllerInput.tilt}] " +
            $"[Button1 : {ControllerInput.button1}] " +
            $"[Button2 : {ControllerInput.button2}] ");
        RawData.text = string.Format($"" +
            $"[Jump sensor : {ControllerInput.jump}] " +
            $"[Tilt sensor : {ControllerInput.jump}]");
    }
}
