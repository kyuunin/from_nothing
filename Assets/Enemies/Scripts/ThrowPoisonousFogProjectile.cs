using System;
using UnityEngine;

public class ThrowPoisonousFogProjectile : MonoBehaviour
{
    [SerializeField]
    private int DurationForNextThrow;

    [SerializeField]
    private GameObject PoisonousFogProjectilePrefab;

    [SerializeField]
    private GameObject Player;

    private DateTime? _timer;

    // Update is called once per frame
    private void Update()
    {
        if (_timer.HasValue && (DateTime.Now - _timer.Value).TotalMilliseconds < DurationForNextThrow)
            return;

        _timer = DateTime.Now;

        Instantiate(PoisonousFogProjectilePrefab, transform.position - new Vector3(0f, 1f), Quaternion.identity);
    }
}
