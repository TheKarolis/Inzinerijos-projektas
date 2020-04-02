using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField]
    GameObject[] NumberButtons;

    [SerializeField]
    Transform CountTr;

    [SerializeField]
    GameObject selectPlayersText;

    private void Awake()
    {
        //EventSystem.main.OnSelectGame += SelectGame;
        SelectGame(null);
    }

    public void SelectGame(Game game)
    {
        if(game)
        {
            selectPlayersText.SetActive(true);
            SetButtons(game.minPlayers, game.maxPlayers);
        }
        else
        {
            selectPlayersText.SetActive(false);
            SetButtons(0,0);
        }
    }


    void SetButtons(int min, int max)
    {
        for (int i = 0; i < CountTr.childCount; i++)
        {
            if (i+1 >= min && i < max)
            {
                CountTr.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                CountTr.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void SelectPlayers(int amount)
    {
        EventSystem.main.CreatePlayers(amount);
    }
}
