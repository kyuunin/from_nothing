using System;
using UnityEngine;

public class PatrolInAirUpAndDownThroughPlayer : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private int DirectionTurnTime;

    private DateTime? _timer = null;

    private int _direction = 1;

    // Update is called once per frame
    void Update()
    {
        var boundsOfEnemyCollider = GetComponent<Collider2D>().bounds;

        if (((_timer.HasValue && (DateTime.Now - _timer.Value).TotalMilliseconds >= DirectionTurnTime) || !_timer.HasValue) && Utilities.IsAtTheGroundOrAtTheRoof(boundsOfEnemyCollider))
        {
            _direction *= -1;
            _timer = DateTime.Now;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, _direction * Speed);
    }
}
