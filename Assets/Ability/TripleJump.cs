
using UnityEngine;

public class TripleJump : MonoBehaviour
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
            jumpStarted = false;
        //jump Started
        if (!jumpStarted && commonValues.DannyDoubleD && Input.GetButtonDown("Vertical") && !isGrounded())
        {
            jumpStarted = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed * doubleJumpModifier);
        }
    }
}
