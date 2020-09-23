using UnityEngine;

public class RightMovement : MonoBehaviour, IAbility
{
    // Update is called once per frame
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal <= 0)
            return;
        var tmp = commonValues.RigidBodyOfPlayer.velocity;
        commonValues.RigidBodyOfPlayer.velocity = new Vector2(commonValues.HorizontalMoveSpeed * inputHorizontal, tmp.y);
    }
}
