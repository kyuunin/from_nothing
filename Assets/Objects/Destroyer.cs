using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Door;
    private IDoor _door;
    public string AttackName;
    private void Start()
    {
        _door = Door.GetComponent<IDoor>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.gameObject);
        if (collision.gameObject.GetComponent(AttackName) != null) {
            Door.GetComponent<IDoor>().SetOpen(true);
        }
    }
}
