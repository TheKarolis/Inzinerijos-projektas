using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GameInput : ScriptableObject
{
    public abstract bool TiltUp { get; }
    public abstract bool Button { get; }

    public virtual bool Initialize()
    {
        return true;
    }
}
