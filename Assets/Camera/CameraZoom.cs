using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float Zoom = 1;
    public GameObject Cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cam.GetComponent<Camera>().orthographicSize = Zoom;
    }
}
