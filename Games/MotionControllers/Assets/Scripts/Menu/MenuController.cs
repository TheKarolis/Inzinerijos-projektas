using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public string startingTabName;


    public float fadeOutDuration;
    public float fadeInDuration;

    [SerializeField]
    CanvasGroup[] tabs;

    Dictionary<string, CanvasGroup> Tabs = new Dictionary<string, CanvasGroup>();

    CanvasGroup currentTab;
    CanvasGroup nextTab;
    string nextTabName;

    private void Awake()
    {
        foreach (var item in tabs)
        {
            Tabs.Add(item.name, item);
            item.gameObject.SetActive(false);
        }
        Tabs[startingTabName].gameObject.SetActive(true);
        currentTab = Tabs[startingTabName];
    }

    public void Navigate(string nextTab)
    {
        this.nextTab = Tabs[nextTab];
        nextTabName = nextTab;
        LeanTween.alphaCanvas(currentTab, 0, fadeOutDuration).setOnComplete(LoadNextTab);
    }

    void LoadNextTab()
    {
        currentTab.gameObject.SetActive(false);
        currentTab = nextTab;
        currentTab.gameObject.SetActive(true);
        LeanTween.alphaCanvas(currentTab, 1, fadeInDuration);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
