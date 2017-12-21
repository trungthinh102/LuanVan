﻿using UnityEngine;


public class PlayerMove : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public VirtualJoyStick joystick;
    public AudioClip audioJump;
    
    public AudioSource audioSource;

    private Animator anim;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private bool jump = false;


    public void Jump()
    {
        jump = true;
        anim.SetBool(Constant.JUMP, true);
        audioSource.clip = audioJump;
        audioSource.Play();
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        if (joystick.move == true)
        {
            
            if (controller.isGrounded)
            {
                
                moveDirection = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;              

                if (jump)
                {
                    moveDirection.y = jumpSpeed;
                    jump = false;
                }
                else
                {
                    anim.SetBool(Constant.JUMP, false);
                }
                anim.SetBool(Constant.WALK, true);
                
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            
        }
        else
        {
            anim.SetBool(Constant.WALK, false);
            //audioSource.Stop();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
                if (jump)
                {
                    moveDirection.y = jumpSpeed;
                    jump = false;
                   
                }
                else
                {
                    anim.SetBool(Constant.JUMP, false);
                }


            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            

        }
        
        
    }
}