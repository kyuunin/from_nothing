using UnityEngine;

public static class Utilities {

    public static bool IsGrounded()
    {
        var boundsOfPlayerCollider = CommonValuesStore.CommonValues.ColliderOfPlayer.bounds;
        var platformLayerMask = CommonValuesStore.CommonValues.PlatformLayerMask;

        var raycastHit2d = Physics2D.BoxCast(boundsOfPlayerCollider.center, boundsOfPlayerCollider.size, 0f, Vector2.down, .1f, platformLayerMask);

        return raycastHit2d.collider != null;
    }
}
