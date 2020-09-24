using System;
using UnityEngine;

public class LightningProjectileScript : MonoBehaviour
{
    public int damage;
    public int lifeTime;

    private int _dannyDirection;
    private DateTime? timer = null;

    private void Start()
    {
        timer = DateTime.Now;
    }

    //deal damage ONCE
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //deal damage
        var enemy = collision.gameObject.GetComponent<DamageEnemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
    }

    void Update()
    {
        //follow player
        transform.position=CommonValuesStore.CommonValues.ColliderOfPlayer.bounds.center + new Vector3(0.03f, 0.16f, 0);
        //destroy at end of duration
        if ((DateTime.Now - timer).Value.TotalMilliseconds > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
