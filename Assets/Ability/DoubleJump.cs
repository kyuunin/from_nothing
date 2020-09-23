
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float doubleJumpModifier;
    private bool jumpStarted;

    private bool isGrounded()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        return Utilities.IsGrounded(transform.GetComponent<BoxCollider2D>().bounds, commonValues.LayerMask);
    }

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        if (isGrounded())
        {
            jumpStarted = false;
            commonValues.DannyDoubleD = false;
        }
        if (commonValues.inDash)
            return;
        //jump Started
        if (!jumpStarted && Input.GetButtonDown("Vertical") && !isGrounded())
        {
            jumpStarted = true;
            commonValues.DannyDoubleD = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed*doubleJumpModifier);
        }
    }
}
