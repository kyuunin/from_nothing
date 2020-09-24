using System;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int Damage = 1;

    private bool _isInPlayerCollision = false;

    // Update is called once per frame
    void Update()
    {
        if (!_isInPlayerCollision)
            return;

        if (ValuesStore.CommonValues.PlayerIsSafeStartTime.HasValue
            && (DateTime.Now - ValuesStore.CommonValues.PlayerIsSafeStartTime.Value) < DamageValues.PlayerIsSafeTimeSpan)
            return;

        ValuesStore.CommonValues.PlayerIsSafeStartTime = DateTime.Now;

        ValuesStore.CommonValues.LivesOfPlayer -= Damage;

        if (ValuesStore.CommonValues.LivesOfPlayer <= 0)
            ValuesStore.Manager.Reload();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        _isInPlayerCollision = collision.gameObject == ValuesStore.Player;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == ValuesStore.Player)
            _isInPlayerCollision = false;
    }
}
