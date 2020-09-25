using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour, IDoor
{
    public Sprite ClosedSprite;
    public Sprite OpenSprite;
    public bool IsOpen = false;
    private SpriteRenderer render = null;
    private BoxCollider2D col = null;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        render.sprite = IsOpen ? OpenSprite : ClosedSprite;
        col.enabled = !IsOpen;
    }
    public virtual void SetOpen(bool open) {
        IsOpen = open;
        render.sprite = IsOpen ? OpenSprite : ClosedSprite;
        col.enabled = !IsOpen;
    }
}
