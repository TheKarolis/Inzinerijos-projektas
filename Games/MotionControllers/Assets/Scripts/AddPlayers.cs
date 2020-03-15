using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPlayers : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(InfoGameDisplay.selectedGame.sceneName);
    }
}
