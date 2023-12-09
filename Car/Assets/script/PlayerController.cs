using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEnum
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform topLeftTransform;
    public Transform topRightTransform;
    public Transform bottomRightTransform;
    public Transform bottomLeftTransform;
    

    private TargetEnum nextTarget = TargetEnum.TopLeft; //Gán trạng thái
    private Transform currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        currentTarget = topLeftTransform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = currentTarget.position;
        Vector3 moveDirection = targetPosition - transform.position;//Đường đi

        float distance = moveDirection.magnitude; //Tính khoảng cách giữa 2 tọa độ

        if(distance > 0.01f)
        {
            //Khi chưa tới điểm tiếp theo vẫn tiếp tục di chuyển
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
                                                    //vị trí hiện tại, vị trí target,thời gian chuyển khung hình
        }
        else
        {
            //chuyển target
            SetNextTarget(nextTarget);
        }

        //Thay đổi theo hướng Target
        Vector3 direction = currentTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;
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
