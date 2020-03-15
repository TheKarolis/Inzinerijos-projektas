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
        EventSystem.main.OnSelectGame += SelectGame;
        SelectGame(null);
    }

    void SelectGame(Game game)
    {
        if(game)
        {
            selectPlayersText.SetActive(true);
            SetButtons(game.minPlayers, game.maxPlayers);
        }
        else
        {
            selectPlayersText.SetActive(false);
            StartCoroutine(DelayedButtons());
        }
    }

    IEnumerator DelayedButtons()
    {
        yield return 0;
        SetButtons(100,100);
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
        Debug.Log(amount);

    }
}
