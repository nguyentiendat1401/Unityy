using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScrips : MonoBehaviour
{
    public int mySpeed;
    public int mypublic = 5;
    public string mystring;
    public double mydouble = 6.2f;

    public GameObject cube2;
    private MeshRenderer meshRenderer;
    //public BoxCollider collider;
    //public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        printValue();
        meshRenderer = cube2.GetComponent<MeshRenderer>();
        ChangeColor();
    }


    void printValue()
    {
        Debug.Log("Mypublic " + mypublic);
        Debug.Log("MyString " + mystring);
    }
    // Update is called once per frame
    void Update()
    {
        RotateObject();
        moveObject();
        
    }


    //Xoay Cube: Transform
    void RotateObject()
    {
        cube2.transform.Rotate(Vector3.up * 50f * Time.deltaTime);
    }

    void moveObject()
    {
        cube2.transform.position = new Vector3(cube2.transform.position.x + mySpeed * Time.deltaTime, 0f, 0f);
    }

    void ChangeColor()
    {
        meshRenderer.material.color = new Color32(255, 1, 2, 241);
    }
}
