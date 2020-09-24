using System;
using UnityEngine;

public class DestroyOnCollisionAfter : MonoBehaviour
{
    [SerializeField]
    private int DurationForSelfDestruction;

    private DateTime? _timer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_timer.HasValue)
            _timer = DateTime.Now;
    }

    private void Update()
    {
        if (_timer.HasValue && (DateTime.Now - _timer.Value).TotalMilliseconds >= DurationForSelfDestruction)
            Destroy(gameObject);
    }
}
