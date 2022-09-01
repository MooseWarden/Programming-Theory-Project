using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

//execute this after game manager to make sure its all loaded up first before setting up the ui
[DefaultExecutionOrder(1000)]

public class MenuUIScript : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (playerNameInput.text.Trim().Length == 0)
        {
            GameManager.instance.playerName = "Player";
        }
        else
        {
            GameManager.instance.playerName = playerNameInput.text;
        }

        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
