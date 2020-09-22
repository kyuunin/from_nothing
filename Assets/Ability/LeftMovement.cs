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
        if (inputHorizontal >= 0)
            return;
        var movement = new Vector3(commonValues.Speed * inputHorizontal, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
