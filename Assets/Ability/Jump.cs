using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool jumpStarted;

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var isInputVertical = Input.GetAxisRaw("Vertical")>0.1;
        //jump Started
        if (isInputVertical && Utilities.IsGrounded(transform.GetComponent<BoxCollider2D>().bounds, commonValues.LayerMask))
        {
            jumpStarted = true;
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed);
        } //jump continue
        else if (jumpStarted && isInputVertical && commonValues.RigidBodyOfPlayer.velocity.y > 0)
        {
            commonValues.RigidBodyOfPlayer.AddForce(new Vector2(0, commonValues.JumpAcceleration));
        }
        else // jump key released
            jumpStarted = false;

    }
}
