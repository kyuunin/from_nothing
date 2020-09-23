using System;
using UnityEngine;

public class Dash : MonoBehaviour
{

    private int dashable; //0=false, 1=true, 2=in Dash
    public float dashDuration;
    private DateTime? timer = null;
    private int direction;
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var isInputDash = Input.GetAxisRaw("Dash") > 0.1;
        var isInputHorizontal = Input.GetAxisRaw("Horizontal");

        //start dash
        if (dashable == 1 && Input.GetButtonDown("Dash"))
        {
            direction = commonValues.DannyDirection ? 1 : -1;
            dashable = 2;
            timer = DateTime.Now;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(direction*commonValues.DannyDashSpeed, 0);
            commonValues.inDash = true;
        } //during dash
        else if (dashable == 2 && ((DateTime.Now - timer.Value).TotalMilliseconds < dashDuration))
        {
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(direction*commonValues.DannyDashSpeed, 0);
        }//after dash, on ground
        else if (Utilities.IsGrounded())
        {
            dashable = 1;
            commonValues.inDash = false;
        }//a
        else
        {
            commonValues.inDash = false;
        }
    } 
}
