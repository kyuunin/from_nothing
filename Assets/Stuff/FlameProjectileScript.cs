using System;
using UnityEngine;

public class FlameProjectileScript : MonoBehaviour
{
    public int damage;
    public int lifeTime;

    private int _dannyDirection;
    private DateTime? timer = null;

    private void Start()
    {
        timer = DateTime.Now;
    }

    //deal damage ONCE
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Update()
    {
        if ((DateTime.Now - timer).Value.TotalMilliseconds > lifeTime)
            Destroy(gameObject);
    }
}
