using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Animator animator;
    public Rigidbody2D rb2D;

    private Vector2 movement;

    private void Update()
    {
        InputControl();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    public void InputControl()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }

    public void Movement()
    {
        rb2D.velocity = movement * 200 * Time.fixedDeltaTime;

        if(movement != Vector2.zero)
        {
            animator.SetBool(AnimatorParameters.Run, true);
        }
        else
        {
            animator.SetBool(AnimatorParameters.Run, false);
        }

        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
