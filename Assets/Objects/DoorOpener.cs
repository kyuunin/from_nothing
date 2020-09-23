using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Sprite ClosedSprite;
    public Sprite OpenSprite;
    public bool IsOpen = false;
    private SpriteRenderer render = null;
    private BoxCollider2D collider = null;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        render.sprite = IsOpen ? OpenSprite : ClosedSprite;
        collider.enabled = !IsOpen;
    }
    public void SetOpen(bool open) {
        IsOpen = open;
        render.sprite = IsOpen ? OpenSprite : ClosedSprite;
        collider.enabled = !IsOpen;
    }
}
