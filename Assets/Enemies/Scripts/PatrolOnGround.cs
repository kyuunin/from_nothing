using UnityEngine;

public class PatrolOnGround : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var boundsOfEnemyCollider = GetComponent<Collider2D>().bounds;

        if (!Utilities.IsGrounded(boundsOfEnemyCollider))
            return;

        if (Utilities.IsInfrontOfAWall(boundsOfEnemyCollider))
            _direction *= -1;

        GetComponent<Rigidbody2D>().velocity = new Vector2(_direction * Speed, 0);
    }
}
