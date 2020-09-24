using System;
using UnityEngine;

public abstract class ThrowProjectile : MonoBehaviour
{
    protected abstract Vector3 SpanPosition { get; }

    [SerializeField]
    private int DurationForNextThrow;

    [SerializeField]
    private GameObject ProjectilePrefab;

    private DateTime? _timer;

    // Update is called once per frame
    private void Update()
    {
        if (_timer.HasValue && (DateTime.Now - _timer.Value).TotalMilliseconds < DurationForNextThrow)
            return;

        _timer = DateTime.Now;

        Instantiate(ProjectilePrefab, transform.position + SpanPosition, Quaternion.identity);
    }
}
