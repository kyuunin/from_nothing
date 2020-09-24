using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField]
    private int life;

    public virtual void TakeDamage(int damage, AttackType attackType)
    {
        life -= damage;
    }

    // Update is called once per frame
    private void Update()
    {
        if (life <= 0)
            Destroy(gameObject);
    }
}
