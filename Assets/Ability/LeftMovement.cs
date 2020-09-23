using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal >= 0 || commonValues.inDash)
            return;
        commonValues.RigidBodyOfPlayer.AddForce(new Vector2(commonValues.HorizontalMoveSpeed * inputHorizontal, 0));
        commonValues.DannyDirection = false;
    }
}
