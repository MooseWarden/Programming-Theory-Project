using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShapeScript : MonoBehaviour
{
    protected TextMeshProUGUI describeText;

    //ENCAPSULATION
    private string backingObjName;
    public string ObjName
    {
        get { return backingObjName; }
        set
        {
            //set char limit, accepting only the first 10 chars of a string
            if (value.Length > 10)
            {
                value = value.Substring(0, 9);
            }

            backingObjName = value;
        }
    }

    //ENCAPSULATION
    private Material backingColor;
    public Material Color
    {
        get { return backingColor; }
        set
        {
            //set color bounds, if go out of range force the values to a neutral grey color
            if (value.color.r > 1.0f)
            {
                value.color = new Color(0.5f, value.color.g, value.color.b);
            }

            if (value.color.g > 1.0f)
            {
                value.color = new Color(value.color.r, 0.5f, value.color.b);
            }

            if (value.color.b > 1.0f)
            {
                value.color = new Color(value.color.r, value.color.g, 0.5f);
            }

            backingColor = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        describeText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        GiveObjName();
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        SpinObj();
    }

    public void GiveObjName() //ABSTRACTION
    {
        ObjName = gameObject.name;
    }

    public void SpinObj() //ABSTRACTION
    {
        transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime, Space.World);
    }

    public void RevertText() //ABSTRACTION
    {
        describeText.text = GameObject.Find("Canvas").GetComponent<MenuUIScript>().baseDescription;
    }

    public virtual void DisplayText() //ABSTRACTION: to be overridden in the child classes
    {
        describeText.text = "This is placeholder text for the shape class.";
    }

    public virtual void ChangeColor() //ABSTRACTION: to be overridden in the child classes
    {
        Color = GetComponent<MeshRenderer>().material;
        Color.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
