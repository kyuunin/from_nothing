using System;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public int cooldown;
    private DateTime? timer = null;

    [SerializeField]
    private GameObject projectile;
    private int _dannyDirection;

    void Start()
    {
        timer = DateTime.Now;
    }

    void Update()
    {
        var isInputAggressive = Input.GetButtonDown("FlameAtak");
        if ((DateTime.Now - timer).Value.TotalMilliseconds < cooldown)
            return;
        //Jot Dora
        if (isInputAggressive)
        {
            if (!Utilities.IsGrounded())
                return;
            _dannyDirection = CommonValuesStore.CommonValues.DannyDirection ? 1 : -1;
            if (_dannyDirection == -1)
                Instantiate(projectile, CommonValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(_dannyDirection * 0.7f, 0, 0), new Quaternion(0, 180, 0, 0));

            else
                Instantiate(projectile, CommonValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(_dannyDirection * 0.7f, 0, 0), Quaternion.identity);
            timer = DateTime.Now;
        }
    }
}
