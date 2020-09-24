using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonController : MonoBehaviour
{
    public DoorOpener Door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Door.SetOpen(true);
    }
}
