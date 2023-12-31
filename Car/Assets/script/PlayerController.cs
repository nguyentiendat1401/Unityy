﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEnum
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
}

public enum DriveMode
{
    Manual,
    Auto,
}
public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public Transform topLeftTransform;
    public Transform topRightTransform;
    public Transform bottomRightTransform;
    public Transform bottomLeftTransform;
    

    private TargetEnum nextTarget = TargetEnum.TopLeft; //Gán trạng thái
    private Transform currentTarget;

    private DriveMode mode = DriveMode.Manual;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = topLeftTransform;
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == DriveMode.Auto)
        {
            AutoMode();
        }
        else if(mode == DriveMode.Manual)
        {
            FixedUpdate();
        }
    }

    void AutoMode()
    {
        Vector3 targetPosition = currentTarget.position;
        Vector3 moveDirection = targetPosition - transform.position;

        float distance = moveDirection.magnitude; // Tính khoảng cách giữa 2 tọa độ

        if (distance > 0.1f)
        {
            // Khi chưa tới điểm tiếp theo thì vẫn tiếp tục di chuyển
            transform.position = Vector3.MoveTowards(transform.position,
                currentTarget.position, speed * Time.deltaTime);

            // Từ frame 1 => frame 2  
        }
        else
        {
            // Chuyen target
            SetNextTarget(nextTarget);
        }

        // Thay đổi góc quay theo hướng target
        Vector3 direction = currentTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;
    }

    //void ManualMode()
    //{

       

        /*
        // Input.GetAxis
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

     
        
        // Tính toán vector di chuyển dựa trên input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Áp vị trí 
        transform.Translate(movement);

        Debug.Log(horizontalInput + ", " + verticalInput);
        */
    //}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0f, v) * speed * Time.deltaTime;
        //rb.AddForce(speed * movement);
        transform.Translate(movement);

        

    }
    void SetNextTarget(TargetEnum target)
    {
        switch (target)
        {
            case TargetEnum.TopLeft:
                currentTarget = topLeftTransform;
                nextTarget = TargetEnum.TopRight;
                break;
            case TargetEnum.TopRight:
                currentTarget = topRightTransform;
                nextTarget = TargetEnum.BottomRight;
                break;
            case TargetEnum.BottomRight:
                currentTarget = bottomRightTransform;
                nextTarget = TargetEnum.BottomLeft;
                break;
            case TargetEnum.BottomLeft:
                currentTarget = bottomLeftTransform;
                nextTarget = TargetEnum.TopLeft;
                break;
            
        }
    }
}
