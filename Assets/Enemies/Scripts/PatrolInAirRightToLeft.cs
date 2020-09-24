using UnityEngine;

public class PatrolInAirRightToLeft : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private int _direction = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != Layer.PlayerLayer)
            return;

        _direction *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        var boundsOfEnemyCollider = GetComponent<Collider2D>().bounds;

        if (Utilities.IsInfrontOfAWall(boundsOfEnemyCollider))
            _direction *= -1;

        GetComponent<Rigidbody2D>().velocity = new Vector2(_direction * Speed, 0);
    }
}
