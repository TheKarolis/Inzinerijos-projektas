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

    public event Action<Game> OnUpdateGameInfo;
    public void UpdateGameInfo(Game game)
    {
        if (OnUpdateGameInfo != null)
        {
            OnUpdateGameInfo(game);
        }
    }
    public event Action<Game> OnSelectGame;
    public void SelectGame(Game game)
    {
        if (OnSelectGame != null)
        {
            OnSelectGame(game);
        }
    }
}
