using UnityEngine;

public static class Utilities {

    public static bool IsGrounded()
    {
        var boundsOfPlayerCollider = CommonValuesStore.CommonValues.ColliderOfPlayer.bounds;

        return IsGrounded(boundsOfPlayerCollider);
    }

    public static bool IsGrounded(Bounds boundsCollider)
    {
        var platformLayerMask = CommonValuesStore.CommonValues.PlatformLayerMask;

        var raycastHit2d = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.down, .1f, platformLayerMask);

        return raycastHit2d.collider != null;
    }

    public static bool IsInfrontOfAWall(Bounds boundsCollider)
    {
        var platformLayerMask = CommonValuesStore.CommonValues.PlatformLayerMask;

        var raycastHitRightWall = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.right, .1f, platformLayerMask);
        var raycastHitLeftWall = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.left, .1f, platformLayerMask);

        return raycastHitRightWall.collider != null
            || raycastHitLeftWall.collider != null;
    }
}
