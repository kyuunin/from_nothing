using System;
using UnityEngine;

public class MineScript : MonoBehaviour
{

    public int damage;

    private DateTime? timer = null;
    private Vector2 bounds;
    private DateTime? explodedTimer = null;
    // Start is called before the first frame update
    void Start()
    {
        timer = DateTime.Now;
        bounds = GetComponent<BoxCollider2D>().size;
        bounds.x *= 3.5f;
        bounds.y *= 3.5f;
    }

    //destroy projectile and calc damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            return;
        }
        //deal damage
        if (collision.gameObject.layer == 9) {
            //explosion
            GetComponent<BoxCollider2D>().size = bounds;
            //selfdestruct
            explodedTimer = DateTime.Now;
            //player takes damage
            if (DamageValues.PlayerIsSafeStartTime.HasValue
                && (DateTime.Now - DamageValues.PlayerIsSafeStartTime.Value) < DamageValues.PlayerIsSafeTimeSpan)
                return;

            DamageValues.PlayerIsSafeStartTime = DateTime.Now;

            DamageValues.LivesOfPlayer -= damage;

            if (DamageValues.LivesOfPlayer <= 0)
                Destroy(ValuesStore.Player);

            //damage enemies too
            var enemy = collision.gameObject.GetComponent<DamageEnemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (explodedTimer != null && (DateTime.Now - explodedTimer).Value.TotalMilliseconds > 50)
            Destroy(gameObject);
    }
}
