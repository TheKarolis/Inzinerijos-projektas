using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static List<Player> Players = new List<Player>();

    public static void AddPlayers(Player player)
    {
        if(!Players.Contains(player))
        {
            Players.Add(player);
        }
    }

    public static void LoadPlayers()
    {

    }
}
