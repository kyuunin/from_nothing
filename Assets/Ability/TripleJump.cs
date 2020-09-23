using System;
using UnityEngine;

public class TripleJump : MonoBehaviour
{
    public float doubleJumpModifier;
    private bool jumpStarted;
    private DateTime? timer = null;

    private bool isGrounded()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        return Utilities.IsGrounded(transform.GetComponent<BoxCollider2D>().bounds, commonValues.LayerMask);
    }

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        if (isGrounded()) //reset jump
        {
            jumpStarted = false;
            timer = null;
            return;
        }
        if (commonValues.inDash)
            return;
        if (commonValues.DannyDoubleD && timer == null)
        {
            timer = DateTime.Now;
        }
        else if (timer.HasValue && (DateTime.Now - timer).Value.TotalMilliseconds < 20)
        {
            return;
        } //jump Started
        else if (Input.GetButtonDown("Vertical") && timer.HasValue && !jumpStarted && commonValues.DannyDoubleD &&  !isGrounded())
        {
            jumpStarted = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed * doubleJumpModifier);
            timer = null;
        }
    }
}
