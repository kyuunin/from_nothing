public class DamageIceEnemy : DamageEnemy
{
    public override void TakeDamage(int damage, AttackType attackType)
    {
        if (attackType != AttackType.Fire)
            return;

        base.TakeDamage(damage, attackType);
    }
}