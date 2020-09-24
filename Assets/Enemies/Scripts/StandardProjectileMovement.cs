using UnityEngine;

public class StandardProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
    }
}
