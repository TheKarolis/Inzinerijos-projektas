using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Keyboard", menuName = "Input/Keyboard")]
public class Keyboard : GameInput
{
    static List<KeyCode> usedKeys = new List<KeyCode>();

    [SerializeField]
    KeyCode tiltKey;
    [SerializeField]
    KeyCode buttonKey;
    public override bool Initialize()
    {
        if(usedKeys.IndexOf(tiltKey) != -1 || usedKeys.IndexOf(buttonKey) != -1)
        {
            return false;
        }

        usedKeys.Add(tiltKey);
        usedKeys.Add(buttonKey);
        return true;
    }

    public override bool TiltUp
    {
        get
        {
            return Input.GetKey(tiltKey);
        }
    }

    public override bool Button
    {
        get
        {
            return Input.GetKey(buttonKey);
        }
    }
}
