using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up, 1f); //Xoay object quanh 1 trục Vector3.up = Vector3(0,1,0)
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
