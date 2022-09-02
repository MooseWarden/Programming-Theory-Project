using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public GameObject shape; //have to populate this in editor

    private TextMeshProUGUI buttonName;
    private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
        buttonName = GetComponentInChildren<TextMeshProUGUI>();
        buttonName.text = shape.GetComponent<ShapeScript>().ObjName + " Button";
        shape.SetActive(toggle);
    }

    public void ToggleShape()
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

    public void ForceOff()
    {
        shape.SetActive((toggle = false));
    }
}
