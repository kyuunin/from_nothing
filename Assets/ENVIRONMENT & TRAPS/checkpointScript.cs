using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    //press down to save
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxisRaw("Aim")< -0.1)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
