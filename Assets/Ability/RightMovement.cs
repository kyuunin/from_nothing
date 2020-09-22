using UnityEngine;

public class RightMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal <= 0)
            return;
        var movement = new Vector3(commonValues.Speed * inputHorizontal, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
