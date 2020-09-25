using UnityEngine;

public static class Utilities {

    public static bool IsGroundedForPlayer()
    {
        var circleColliderOfPlayer = (CircleCollider2D)ValuesStore.CommonValues.ColliderOfPlayer;

        var platformLayerMask = ValuesStore.CommonValues.PlatformLayerMask;

        var raycastHit2d = Physics2D.BoxCast(circleColliderOfPlayer.bounds.center, Vector2.one * 0.4f, 0f, Vector2.down, 0.1f, platformLayerMask);

        return raycastHit2d.collider != null;
    }

    public static bool IsGrounded(Bounds boundsCollider)
    {
        var platformLayerMask = ValuesStore.CommonValues.PlatformLayerMask;

        var raycastHit2d = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, Vector2.down, 0.1f, platformLayerMask);

        return raycastHit2d.collider != null;
    }

    public static bool IsInfrontOfAWall(Bounds boundsCollider)
    {
        var platformLayerMask = ValuesStore.CommonValues.PlatformLayerMask;

        return IsInfrontOf(boundsCollider, platformLayerMask, 0.02f, Vector2.right, Vector2.left);
    }

    public static bool IsAtTheGroundOrAtTheRoof(Bounds boundsCollider)
    {
        var platformLayerMask = ValuesStore.CommonValues.PlatformLayerMask;

        return IsInfrontOf(boundsCollider, platformLayerMask, 0.001f, Vector2.up, Vector2.down);
    }

    private static bool IsInfrontOf(Bounds boundsCollider, LayerMask layerMask, float distance, Vector2 firstDirection, Vector2 secondDirection)
    {
        var raycastHitAtFirstDirection = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, firstDirection, distance, layerMask);
        var raycastHitAtSecondDirection = Physics2D.BoxCast(boundsCollider.center, boundsCollider.size, 0f, secondDirection, distance, layerMask);

        return raycastHitAtFirstDirection.collider != null
            || raycastHitAtSecondDirection.collider != null;
    }
}