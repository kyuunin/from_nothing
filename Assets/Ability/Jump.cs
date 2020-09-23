using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool jumpStarted;
    private DateTime? timer = null;

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var isInputVertical = Input.GetAxisRaw("Vertical")>0.1;

        //jump Started
        if (isInputVertical && timer.HasValue && Utilities.IsGrounded(transform.GetComponent<BoxCollider2D>().bounds, commonValues.LayerMask) && (DateTime.Now - timer.Value).TotalMilliseconds > 30)
        {
            jumpStarted = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed);
            timer = null;
        } //jump continue
        else if (jumpStarted && isInputVertical && commonValues.RigidBodyOfPlayer.velocity.y > 0)
        {
            commonValues.RigidBodyOfPlayer.AddForce(new Vector2(0, commonValues.JumpAcceleration));
        } else if (!timer.HasValue && Utilities.IsGrounded(transform.GetComponent<BoxCollider2D>().bounds, commonValues.LayerMask))
                timer = DateTime.Now;
        else // jump key released
            jumpStarted = false;

    }
}
