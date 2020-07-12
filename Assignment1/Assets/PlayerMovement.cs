using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;

    bool jump = false;

    bool crouch = false;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        }

        if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    public void onLanding() {
        animator.SetBool("isJumping", false);
    }

    public void onCrouching(bool isCrouching) {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
