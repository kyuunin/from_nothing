﻿using System;
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

        if (DamageValues.PlayerIsSafeStartTime.HasValue
            && (DateTime.Now - DamageValues.PlayerIsSafeStartTime.Value) < DamageValues.PlayerIsSafeTimeSpan)
            return;

        DamageValues.PlayerIsSafeStartTime = DateTime.Now;

        DamageValues.LivesOfPlayer -= Damage;

        if (DamageValues.LivesOfPlayer <= 0)
            Destroy(ValuesStore.Player);
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
