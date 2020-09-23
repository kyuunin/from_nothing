using UnityEngine;

public class DamageEnemy: MonoBehaviour
{
    [SerializeField]
    private int life;

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            Destroy(gameObject);
    }
}
