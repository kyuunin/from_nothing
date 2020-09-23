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

        if (commonValues.inDash || CommonValuesStore.CommonValues.duringFlameAttack)
            return;

        //jump Start
        if (isInputVertical && timer.HasValue && Utilities.IsGrounded())
        {
            jumpStarted = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed);
            timer = null;
        } //jump continue
        else if (jumpStarted && isInputVertical && commonValues.RigidBodyOfPlayer.velocity.y > 0)
        {
            commonValues.RigidBodyOfPlayer.AddForce(new Vector2(0, commonValues.JumpAcceleration));
        }//reset jump
        else if (!timer.HasValue && Utilities.IsGrounded())
        {
            timer = DateTime.Now;
            jumpStarted = false;
        }
    }
}
