﻿using UnityEngine;

public class RightMovement : MonoBehaviour
{
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal <= 0 || commonValues.inDash || ValuesStore.CommonValues.duringFlameAttack)
            return;
        commonValues.RigidBodyOfPlayer.AddForce(new Vector2(commonValues.HorizontalMoveSpeed * inputHorizontal,0));
        commonValues.DannyDirection = true;
    }
}
