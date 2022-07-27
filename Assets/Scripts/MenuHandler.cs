using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{

    public TMP_Text warning;
    public TMP_Text playerName;
    public string input;
    // Start is called before the first frame update
    void Start()
    {
        warning.gameObject.SetActive(false);
        if(SaveData.Instance != null)
        {
            playerName.SetText(SaveData.Instance.playerName);
        }
    }
    public void SetName(string tosave)
    {
        SaveData.Instance.playerName = tosave;
        playerName.SetText(tosave);
    }
    public void InputChange(string newinput)
    {
        input = newinput;
    }    
    
    public void StartGame()
    {
        if(input != "")
        {
            warning.gameObject.SetActive(false);
            SetName(input);
            Debug.Log("Let's start the game "+input);
            SaveData.Instance.SwitchScene(1);
        }
        else{
            warning.gameObject.SetActive(true);
        }
    }
    public void Exit()
    {
        if(input != "")
        {
            SetName(input);
        }
        SaveData.Instance.SaveName();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }

}
