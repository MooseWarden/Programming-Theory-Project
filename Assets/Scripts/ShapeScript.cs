using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShapeScript : MonoBehaviour
{
    protected TextMeshProUGUI describeText;

    //encapsulation section
    private string backingObjName;
    public string ObjName
    {
        get { return backingObjName; }
        set { backingObjName = value; }
    }

    private Material backingColor;
    public Material Color
    {
        get { return backingColor; }
        set { backingColor = value; }
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

    public void GiveObjName()
    {
        ObjName = gameObject.name;
    }

    public void SpinObj()
    {
        transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime, Space.World);
    }

    public void RevertText()
    {
        describeText.text = GameObject.Find("Canvas").GetComponent<MenuUIScript>().baseDescription;
    }

    //polymorphism
    public virtual void ChangeColor()
    {
        Color = GetComponent<MeshRenderer>().material;
        Color.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public virtual void DisplayText()
    {
        describeText.text = "This is placeholder text for the shape class.";
    }
}
