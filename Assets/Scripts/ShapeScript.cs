using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    //encapsulation section
    private string backingObjName = "obj";
    public string ObjName
    {
        get { return backingObjName; }
        set { backingObjName = value; }
    }

    //color field too that changes per shape class? polymorph or encapsulation in practice for the other classes?

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpinObj();
    }

    private void SpinObj()
    {
        transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime, Space.World);
    }

    //polymorphism
    public virtual void DisplayText()
    {
        //associated text object needs to be edited here
    }
}
