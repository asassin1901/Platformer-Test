using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller = null;

    float horizontal = 0f;

    public float moveSpeed = 30f;

    public bool jump = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontal * moveSpeed * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}
