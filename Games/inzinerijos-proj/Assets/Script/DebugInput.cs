using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    void Update()
    {
        ControllerInput.button1 = Input.GetKey(KeyCode.Q);
        ControllerInput.button2 = Input.GetKey(KeyCode.W);
        ControllerInput.jump = Input.GetKey(KeyCode.Space);
        if(Input.GetKey(KeyCode.A))
        {
            ControllerInput.tilt = Input.GetKey(KeyCode.A);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ControllerInput.tilt = Input.GetKey(KeyCode.D);
        }
    }
}
