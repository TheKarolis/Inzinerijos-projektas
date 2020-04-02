using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem main;
    private void Awake()
    {
        main = this;
    }
    public event Action<Game> OnSelectGame;
    public void SelectGame(Game game)
    {
        if (OnSelectGame != null)
        {
            OnSelectGame(game);
        }
    }
    public event Action<int> OnCreatePlayers;
    public void CreatePlayers(int count)
    {
        if (OnCreatePlayers != null)
        {
            OnCreatePlayers(count);
        }
    }

}
