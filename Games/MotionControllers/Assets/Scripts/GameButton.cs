using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    Game game;

    public void UpdateGameInfo()
    {
        EventSystem.main.UpdateGameInfo(game);
    }

    private void OnValidate()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = game.name;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(game.sceneName);
    }

    public void ResetGameInfo()
    {
        EventSystem.main.UpdateGameInfo(null);
    }
    public void SelectGame()
    {
        EventSystem.main.SelectGame(game);
    }
    public void DeselectGame()
    {
        EventSystem.main.SelectGame(null);
    }
}
