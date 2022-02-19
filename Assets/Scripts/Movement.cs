using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator myAnimator = null;
    public CharacterController2D controller = null;

    float horizontal = 0f;

    public float moveSpeed = 30f;

    public bool jump = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            myAnimator.SetBool("Jump", true);
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    public void OnLanding()
    {
        myAnimator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontal * moveSpeed * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}
