using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGlue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        collision.gameObject.transform.parent = gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = gameObject.transform.parent.parent;
    }
}
