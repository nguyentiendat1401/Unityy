using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name); // Lấy tên của vật bị va chạm
        Debug.Log(other.gameObject.tag);

        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("On Trigger Enter");
        }
    }
}
