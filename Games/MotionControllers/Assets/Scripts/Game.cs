using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Game", order = 1)]
public class Game : ScriptableObject
{
    [TextArea]
    public string description;

    public Sprite thumbnail;
    public string sceneName;

    public int minPlayers;
    public int maxPlayers;
}
