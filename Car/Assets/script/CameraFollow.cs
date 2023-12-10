using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Đối tượng mà xe follow
    [SerializeField] private float speed = 0.125f;
    [SerializeField] private Vector3 offset; //khoảng cách từ camera đến mục tiêu


    private void LateUpdate()
    {
        //Tạo một vị trí mới mà camera sẽ di chuyển tới
        Vector3 newPosition = target.position + offset;
        Vector3 smootdCamera = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

        //Cập nhật vị trí camera
        transform.position = smootdCamera;
    }
}
