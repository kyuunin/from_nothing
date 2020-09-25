using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonController : MonoBehaviour
{
    public GameObject Door;
    private IDoor _door;
    private void Start()
    {
        _door = Door.GetComponent<IDoor>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _door.SetOpen(true);
    }
}
