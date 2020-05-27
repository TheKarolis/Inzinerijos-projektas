using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoGameDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Header;
    [SerializeField]
    TextMeshProUGUI Content;

    public static Game selectedGame;

    private void Awake()
    {
        EventSystem.main.OnSelectGame += SelectGame;
    }
    void SelectGame(Game game)
    {
        selectedGame = game;
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0, 0.2f).setOnComplete(Switch);
    }
    void Switch()
    {
        Header.text = selectedGame.name;
        Content.text = selectedGame.description;
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1, 0.2f);
    }
    public void Play()
    {
        SceneManager.LoadScene(selectedGame.sceneName);
    }
}
