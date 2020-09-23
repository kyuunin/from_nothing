using UnityEngine;

public class RightMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal <= 0 || commonValues.inDash)
            return;
        commonValues.RigidBodyOfPlayer.AddForce(new Vector2(commonValues.HorizontalMoveSpeed * inputHorizontal,0));
        commonValues.DannyDirection = true;
    }
}
