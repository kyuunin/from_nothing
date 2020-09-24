using System;
using UnityEngine;

public class BombProjectileScript : MonoBehaviour
{
    public int damage;
    public int lifetime;

    private DateTime? timer = null;
    private float radius;
    private DateTime? explodedTimer = null;

    private void Start()
    {
        timer = DateTime.Now;
        radius = GetComponent<CircleCollider2D>().radius * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollisionOrTriggerEnter(collision.gameObject);
    }

    //destroy projectile and calc damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionOrTriggerEnter(collision.gameObject);
    }

    private void OnCollisionOrTriggerEnter(GameObject gameObject)
    {
        if (gameObject.layer == 9 || gameObject.layer == 8)
        {
            if (gameObject.layer == 8)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            return;
        }
        //deal damage
        //explosion
        GetComponent<CircleCollider2D>().radius = radius;
        var enemy = gameObject.GetComponent<DamageEnemy>();
        if (enemy != null)
            enemy.TakeDamage(damage, AttackType.Explosion);
        //selfdestruct
        explodedTimer = DateTime.Now;
    }

    // shoot it, bop it, drop it
    private void Update()
    {
        if (explodedTimer != null && (DateTime.Now - explodedTimer).Value.TotalMilliseconds > 50)
            Destroy(gameObject);
        if ((DateTime.Now - timer).Value.TotalMilliseconds < lifetime)
            return;
        else
        {
            GetComponent<CircleCollider2D>().radius = radius;
            Destroy(gameObject);
        }
    }
}
