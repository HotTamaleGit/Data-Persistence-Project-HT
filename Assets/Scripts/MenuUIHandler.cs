using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public string playerName;
    public Text scoreBoard;
    

    public void SavePlayerName()
    {
        if (inputField != null) 
        {
            playerName = inputField.text;
            Debug.Log("playerName:" + playerName);
            GameManager.Instance.playerName = playerName;
        }
    }

    private void Start()
    {
        GameManager.Instance.LoadHighScore();
        scoreBoard.text = $"Best Score: {GameManager.Instance.bestPlayer}: {GameManager.Instance.highScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GameOverUpdate()
    { 
        scoreBoard.text = $"Best Score: {GameManager.Instance.playerName}: {GameManager.Instance.newHigh}"; 
    }
  
}
