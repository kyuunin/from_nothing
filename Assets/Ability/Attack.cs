using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private DateTime? timer = null;
    public int cooldown;

    [SerializeField]
    private GameObject projectile;
    private int _dannyDirection;

    void Start()
    {
        timer = DateTime.Now;
    }

    void Update()
    {
        var isInputAggressive = Input.GetButtonDown("Atak");
        if ((DateTime.Now - timer).Value.TotalMilliseconds < cooldown)
            return;
        //Jot Dora
        if (isInputAggressive)
        {
            _dannyDirection = ValuesStore.CommonValues.DannyDirection ? 1 : -1;
            if (_dannyDirection == -1)
                Instantiate(projectile, ValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(_dannyDirection * 0.5f, 0, 0), new Quaternion(0,180,0,0));

            else
                Instantiate(projectile, ValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(_dannyDirection*0.5f,0,0), Quaternion.identity);
            timer = DateTime.Now;
        }
    }
}
