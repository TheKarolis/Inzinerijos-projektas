using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerSetup : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown selection;

    [SerializeField]
    GameObject NoPorts;
    [SerializeField]
    GameObject portSelection;

    public Controller editingController;
    private void Awake()
    {
        RefreshPorts();
    }
    public void RefreshPorts()
    {
        string[] ports = Controller.GetPorts();
        selection.options = new List<TMP_Dropdown.OptionData>();

        if (ports.Length <= 0)
        {
            NoPorts.SetActive(true);
            LeanTween.scale(NoPorts.GetComponent<RectTransform>(),new Vector2(1.1f,1.1f),0.1f).setLoopPingPong(1);
            portSelection.SetActive(false);
            return;
        }
        else
        {
            NoPorts.SetActive(false);
            portSelection.SetActive(true);
        }

        Debug.Log("Yes");
        List<string> options = new List<string>(ports);
        selection.AddOptions(options);
    }
    public void SelectOption()
    {
        editingController.portName = selection.itemText.text;
        Debug.Log(selection.itemText.text+"+");
    }

    void UpdateEditing()
    {
        editingController.portName = selection.itemText.text;
    }

    public bool ValidateControllers()
    {
        return true;
    }
}
