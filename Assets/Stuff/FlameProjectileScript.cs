using System;
using UnityEngine;

public class FlameProjectileScript : MonoBehaviour
{
    public int damage;
    public int lifeTime;

    private int _dannyDirection;
    private DateTime? timer = null;

    private void Start()
    {
        timer = DateTime.Now;
        CommonValuesStore.CommonValues.duringFlameAttack = true;
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
        if ((DateTime.Now - timer).Value.TotalMilliseconds > lifeTime) {
            CommonValuesStore.CommonValues.duringFlameAttack = false;
            Destroy(gameObject);
        }
    }
}
