using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//execute this after shapes to make sure shapes are loaded in before pulling shape data
[DefaultExecutionOrder(999)]

public class ButtonScript : MonoBehaviour
{
    public GameObject shape; //have to populate this in editor

    private TextMeshProUGUI buttonName;
    private bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonName = GetComponentInChildren<TextMeshProUGUI>();
        buttonName.text = shape.GetComponent<ShapeScript>().ObjName + " Button";
        shape.SetActive(toggle);
    }

    //ABSTRACTION: to be used by the button object On Click() function
    public void ToggleShape() //turns shape on/off as well as altering display text accordingly
    {
        toggle = !toggle;

        if (toggle == true)
        {
            shape.GetComponent<ShapeScript>().DisplayText();
        }
        else if (toggle == false)
        {
            shape.GetComponent<ShapeScript>().RevertText();
        }

        shape.SetActive(toggle);
    }

    //ABSTRACTION: to be used by the button object On Click() function
    public void ForceOff() //deactivates shape 
    {
        shape.SetActive((toggle = false));
    }
}
