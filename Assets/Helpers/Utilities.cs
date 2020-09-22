using UnityEngine;

public static class Utilities {
    public static bool IsGrounded(Bounds playerCollider, LayerMask layerMask)
    {
        var raycastHit2d = Physics2D.BoxCast(playerCollider.center, playerCollider.size, 0f, Vector2.down, .1f, layerMask);

        Debug.Log(raycastHit2d);

        Debug.Log(raycastHit2d.collider != null);

        return raycastHit2d.collider != null;
    }
}
