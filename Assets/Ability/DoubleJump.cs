
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float doubleJumpModifier;
    private bool jumpStarted;

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        if (Utilities.IsGroundedForPlayer()) //reset jump
        {
            jumpStarted = false;
            commonValues.DannyDoubleD = false;
        }
        if (commonValues.inDash || ValuesStore.CommonValues.duringFlameAttack)
            return;
        //jump Started
        if (!jumpStarted && Input.GetButtonDown("Vertical") && !Utilities.IsGroundedForPlayer())
        {
            jumpStarted = true;
            commonValues.DannyDoubleD = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed*doubleJumpModifier);
        }
    }
}
