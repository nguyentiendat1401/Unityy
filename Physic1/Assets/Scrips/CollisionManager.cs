using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name); // Lấy tên của vật bị va chạm
        Debug.Log(col.relativeVelocity); //Lấy vận tốc tương đối
        Debug.Log(col.rigidbody);
        Debug.Log(col.collider);
    }

    private void OnCollisionStay(Collision col)
    {
        Debug.Log("Stay: " + col.gameObject.name);
    }

    private void OnCollisionExit(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }

    
}
