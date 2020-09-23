using UnityEngine;

public class projectiledotexe : MonoBehaviour
{
    public float speed;
    public int damage;

    private int _dannyDirection;

    //destroy projectile and calc damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deal damage

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
