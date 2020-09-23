using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public float friction=1.0f;
    private CommonValues commonValues;
    // Start is called before the first frame update
    void Start()
    {
        commonValues = transform.GetComponent<CommonValues>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = commonValues.RigidBodyOfPlayer.velocity;
        commonValues.RigidBodyOfPlayer.AddForce(new Vector2(-velocity.x * friction, 0));
    }
}
