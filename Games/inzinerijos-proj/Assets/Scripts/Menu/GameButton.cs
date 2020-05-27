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
    private void OnValidate()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = game.name;
    }
    public void SelectGame()
    {
        EventSystem.main.SelectGame(game);
    }
}
