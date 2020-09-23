using UnityEngine;

public static class Utilities {
    public static bool IsGrounded(Bounds playerCollider, LayerMask layerMask)
    {
        var raycastHit2d = Physics2D.BoxCast(playerCollider.center, playerCollider.size, 0f, Vector2.down, .1f, layerMask);
        
        return raycastHit2d.collider != null;
    }
}
