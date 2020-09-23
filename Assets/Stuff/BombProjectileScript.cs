using System;
using UnityEngine;

public class BombProjectileScript : MonoBehaviour
{
    public int damage;
    public int lifetime;

    private int _dannyDirection;
    private DateTime? timer = null;
    private float radius;
    private DateTime? explodedTimer = null;

    private void Start()
    {
        timer = DateTime.Now;
        _dannyDirection = CommonValuesStore.CommonValues.DannyDirection ? 1 : -1;
        radius = GetComponent<CircleCollider2D>().radius*3;
    }

    //destroy projectile and calc damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
            return;
        Debug.Log(collision);
        //deal damage
        //explosion
        GetComponent<CircleCollider2D>().radius = radius;
        var enemy = collision.gameObject.GetComponent<DamageEnemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        //selfdestruct
        explodedTimer = DateTime.Now;
    }

    // shoot it, bop it, drop it
    void Update()
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
