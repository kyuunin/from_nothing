using UnityEngine;

public class projectiledotexe : MonoBehaviour
{
    public float speed;
    public int damage;

    private int _dannyDirection;

    //destroy projectile and calc damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //deal damage
        var enemy = collision.gameObject.GetComponent<DamageEnemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        //selfdestruct
        Destroy(gameObject);
    }

    private void Start()
    {
        _dannyDirection = CommonValuesStore.CommonValues.DannyDirection ? 1 : -1;
    }

    // shoot it, bop it, drop it
    void Update()
    {
        var projectile = GetComponent<Rigidbody2D>();
        projectile.velocity = new Vector2(_dannyDirection*speed, 0);
    }
}
