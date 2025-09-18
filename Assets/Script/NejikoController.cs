using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.EventSystems;

public class NejikoController : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    Vector3 moveDirection;

    public float gravity;
    public float speedZ;
    public float speedJump;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedZ;

            }
            else
            {
                moveDirection.z = 0;
            }
            transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = speedJump;
                animator.SetTrigger("jump");
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);//方向を加味したVector3を作成
        controller.Move(globalDirection * Time.deltaTime);//向いてるglobalDirectionに
        if (controller.isGrounded) moveDirection.y = 0;
        animator.SetBool("run", moveDirection.z > 0.0f);
        Debug.Log("test");

    }
}
