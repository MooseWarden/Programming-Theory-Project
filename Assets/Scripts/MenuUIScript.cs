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

    [HideInInspector] public string baseDescription;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            TextMeshProUGUI describeText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();

            if (GameManager.instance != null)
            {
                describeText.text = "Please select a shape from the list, " + GameManager.instance.playerName + ".";
            }

            baseDescription = describeText.text;
        }
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
