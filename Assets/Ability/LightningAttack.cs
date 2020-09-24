using System;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    public int cooldown;
    private DateTime? timer = null;

    [SerializeField]
    private GameObject projectile;

    void Update()
    {
        var isInputAggressive = Input.GetButtonDown("LightningAtak");
        if (timer.HasValue && (DateTime.Now - timer).Value.TotalMilliseconds < cooldown)
            return;
        //Jot Dora
        if (isInputAggressive)
        {
            Instantiate(projectile, CommonValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(0.03f, 0.16f, 0), Quaternion.identity);
     timer = DateTime.Now;
        }
    }
}
