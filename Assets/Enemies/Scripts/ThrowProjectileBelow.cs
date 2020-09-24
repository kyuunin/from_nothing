using UnityEngine;

public class ThrowProjectileBelow : ThrowProjectile
{
    protected override Vector3 SpanPosition => new Vector3(0f, -1f);
}
