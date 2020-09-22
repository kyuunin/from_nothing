using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpAcceleration;
    public float JumpDuration;
    // Update is called once per frame

    public LayerMask layerMask; 

    void Update()
    {
        var commonValues = transform.GetComponent<CommonValues>();
        
        var inputHorizontal = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && Utilities.IsGrounded(transform.GetComponent<CapsuleCollider2D>().bounds, layerMask))
        {
            var tmp = commonValues.RigidBodyOfPlayer.velocity;
            commonValues.RigidBodyOfPlayer.velocity = new Vector2(tmp.x, commonValues.JumpSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            commonValues.RigidBodyOfPlayer.AddForce(new Vector2(0, JumpAcceleration));
        }
    }
}
