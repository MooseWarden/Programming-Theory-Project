using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeScript : ShapeScript //INHERITANCE
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

    public override void ChangeColor() //POLYMORPHISM
    {
        Color = GetComponent<MeshRenderer>().material;
        Color.color = new Color(1f, 0f, 0f);
    }

    public override void DisplayText() //POLYMORPHISM
    {
        TextMeshProUGUI describeText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        describeText.text = "This is a " + ObjName + ". Marvel at its many sides.";
    }
}
