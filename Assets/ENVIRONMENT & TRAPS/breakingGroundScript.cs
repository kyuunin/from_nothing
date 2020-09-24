using System;
using UnityEngine;

public class breakingGroundScript : MonoBehaviour
{
    private DateTime? timer = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
            timer = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.HasValue && (DateTime.Now - timer).Value.TotalMilliseconds > ValuesStore.CommonValues.GroundCollapseTiem)
            Destroy(gameObject);
    }
}
