using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoorOpener : DoorOpener
{
    private DateTime? timer = null;
    public bool Default = false;
    public int openTime=1000;

    void Update()
    {
        if(timer.HasValue && (DateTime.Now - timer).Value.TotalMilliseconds > openTime)
        {
            base.SetOpen(Default);
            Debug.Log("close again");
        }
    }

    public override void SetOpen(bool open)
    {
        base.SetOpen(open);
        timer = DateTime.Now;
    }
}
