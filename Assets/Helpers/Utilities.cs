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

    public static bool IsInfrontOfAWallOrThePlayer(Bounds boundsCollider)
    {
        var platformLayerMask = CommonValuesStore.CommonValues.PlatformLayerMask;
        var playerLayerMask = CommonValuesStore.CommonValues.PlayerLayerMask;

        return IsInfrontOf(boundsCollider, platformLayerMask, 0.1f)
            || IsInfrontOf(boundsCollider, playerLayerMask, 0.02f);
    }

    private static bool IsInfrontOf(Bounds boundsCollider, LayerMask layerMask, float distance)
    {
        var raycastHitRightWall = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.right, distance, layerMask);
        var raycastHitLeftWall = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.left, distance, layerMask);

        return raycastHitRightWall.collider != null
            || raycastHitLeftWall.collider != null;
    }
}
