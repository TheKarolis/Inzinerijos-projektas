using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Player editingPlayer;

    public static GameManager main;
    private void Awake()
    {
        if(!main)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LoadGame(Game game)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(game.sceneName);
        load.completed += GameLoaded;
    }

    void GameLoaded(AsyncOperation op)
    {
        EventSystem.main.GameLoaded();
    }
}
