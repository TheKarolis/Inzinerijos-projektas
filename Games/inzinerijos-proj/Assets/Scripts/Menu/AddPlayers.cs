using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AddPlayers : MonoBehaviour
{
    List<Player> connectedPlayers = new List<Player>();

    public GameObject PlayButton;
    public GameObject NextButton;

    [SerializeField]
    TextMeshProUGUI playerText;

    int currentPlayer;
    int maxPlayers;

    private void Start()
    {
        EventSystem.main.OnCreatePlayers += CreatePlayers;
    }
    public void LoadGame()
    {
        EventSystem.main.LoadGame(InfoGameDisplay.selectedGame);
    }
    void CreatePlayers(int count)
    {
        maxPlayers = count;
        currentPlayer = 1;
        CheckCount();
    }
    public void Next()
    {
        currentPlayer++;
        CheckCount();
    }
    void CheckCount()
    {
        if (currentPlayer >= maxPlayers)
        {
            NextButton.SetActive(false);
            PlayButton.SetActive(true);
        }
        else
        {
            NextButton.SetActive(true);
            PlayButton.SetActive(false);
        }
        playerText.text = "Player " + currentPlayer;
    }
}
