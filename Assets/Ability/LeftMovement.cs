using UnityEngine;

public class LeftMovement : MonoBehaviour
{

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal >= 0 || commonValues.inDash || CommonValuesStore.CommonValues.duringFlameAttack)
            return;
        commonValues.RigidBodyOfPlayer.AddForce(new Vector2(commonValues.HorizontalMoveSpeed * inputHorizontal, 0));
        commonValues.DannyDirection = false;
    }
}
