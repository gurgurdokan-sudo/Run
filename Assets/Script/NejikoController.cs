using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

public class NejikoController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    CharacterController controller;
    Animator animator;

    Vector3 moveDirection;
    int targetLane;
    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("left")) MoveToLeft();
        if (Input.GetKeyDown("right")) MoveToRigth();
        if (Input.GetKeyDown("space")) Jump();
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, 0, speedZ);

        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        // if (controller.isGrounded)
        // {
        //     if (Input.GetAxis("Vertical") > 0.0f)
        //     {
        //         moveDirection.z = Input.GetAxis("Vertical") * speedZ;

        //     }
        //     else
        //     {
        //         moveDirection.z = 0;
        //     }
        //     transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);
        //     if (Input.GetButton("Jump"))
        //     {
        //         moveDirection.y = speedJump;
        //         animator.SetTrigger("jump");
        //     }
        // }
        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);//方向を加味したVector3を作成
        controller.Move(globalDirection * Time.deltaTime);//向いてるglobalDirectionに
        if (controller.isGrounded) moveDirection.y = 0;
        animator.SetBool("run", moveDirection.z > 0.0f);

    }
    public void MoveToLeft() {
        if (controller.isGrounded && targetLane > MinLane) targetLane--;
    }
    public void MoveToRigth() {
        if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    }
    public void Jump() {
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
            animator.SetTrigger("jump");
        }
    }
}
