using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public DoorOpener Door;
    public string AttackName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.GetComponent(AttackName) != null) {
            Door.SetOpen(true);
        }
    }
}
