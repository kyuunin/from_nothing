using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMover : Mover, IDoor
{
    public bool active = false;
    public void SetOpen(bool open)
    {
        active = open;
        Debug.Log("open: " +active);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (active) base.Update();
    }
}
