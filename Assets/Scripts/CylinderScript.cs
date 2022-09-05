using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CylinderScript : ShapeScript //inheritance
{
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

    //polymorphism
    public override void ChangeColor()
    {
        Color = GetComponent<MeshRenderer>().material;
        Color.color = new Color(1f, 0.6f, 0f);
    }

    public override void DisplayText()
    {
        TextMeshProUGUI describeText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        describeText.text = "This is a " + ObjName + ". Classic and timeless!";
    }
}
