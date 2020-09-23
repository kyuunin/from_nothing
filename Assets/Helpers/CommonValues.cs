using UnityEngine;

public class CommonValues : MonoBehaviour
{
    public Rigidbody2D RigidBodyOfPlayer;

    public float HorizontalMoveSpeed;
    public float JumpSpeed;
    public float JumpAcceleration;
    public bool DannyDoubleD;
    public float DannyDashSpeed;
    public bool inDash;
    public bool DannyDirection;
    public LayerMask PlatformLayerMask;
    public LayerMask PlayerLayerMask;
    public Collider2D ColliderOfPlayer;
    public bool duringFlameAttack;
}
