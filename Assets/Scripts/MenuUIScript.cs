using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

//execute this after game manager to make sure its all loaded up first before setting up the ui
[DefaultExecutionOrder(1000)]

public class MenuUIScript : MonoBehaviour
{
    private TMP_InputField playerNameInput;

    [HideInInspector] public string baseDescription;

    // Start is called before the first frame update
    void Start()
    {
        //grab input field in menu scene or grab description text in main scene, used to keep everything private and prevent cross scene issues
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            playerNameInput = GameObject.Find("NameInput").GetComponent<TMP_InputField>();
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
            TextMeshProUGUI describeText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();

            if (GameManager.instance != null)
            {
                describeText.text = "Please select a shape from the list, " + GameManager.instance.playerName + ".";
            }

            baseDescription = describeText.text;
        }
    }

    public void StartGame() //ABSTRACTION 
    {
        //check if input field is empty before loading next scene, use default value if so
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

    public void ExitGame() //ABSTRACTION
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
