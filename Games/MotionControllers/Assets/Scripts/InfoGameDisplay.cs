using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoGameDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Header;
    [SerializeField]
    TextMeshProUGUI Content;

    public static Game selectedGame;

    private void Awake()
    {
        EventSystem.main.OnUpdateGameInfo += UpdateDisplay;
        EventSystem.main.OnSelectGame += SelectGame;
    }

    void UpdateDisplay(Game game)
    {
        if(game)
        {
            Header.text = game.name;
            Content.text = game.description;
        }
        else if (selectedGame)
        {
            Header.text = selectedGame.name;
            Content.text = selectedGame.description;
        }
        else
        {
            Header.text = "";
            Content.text = "";
        }
    }

    void SelectGame(Game game)
    {
        selectedGame = game;
        UpdateDisplay(game);
    }
}
