using System;
using UnityEngine;

public class BombThrow : MonoBehaviour
{
    private DateTime? timer = null;
    public int cooldown;
    public float throwStrength;

    [SerializeField]
    private GameObject projectile;
    private int _dannyDirection;

    void Start()
    {
        timer = DateTime.Now;
    }

    void Update()
    {
        var isInputAggressive = Input.GetButtonDown("BombThrow");
        GameObject bomb;
        if ((DateTime.Now - timer).Value.TotalMilliseconds < cooldown)
            return;
        //Jot Dora
        if (isInputAggressive)
        {
            Vector2 velo;
            //top right
            if (Input.GetAxisRaw("Aim") > 0.1) { 
                velo = new Vector2(1, 2);
                velo *= throwStrength;
            }
            else if (Input.GetAxisRaw("Aim") < -0.1) { 
                velo = new Vector2(0, 0);
            }
            else {
                velo = new Vector2(1, 0);
                velo *= throwStrength;
            }
            
            _dannyDirection = CommonValuesStore.CommonValues.DannyDirection ? 1 : -1;
            if (_dannyDirection == -1) {
                velo.x *= -1;
            }
            bomb = Instantiate(projectile, CommonValuesStore.CommonValues.RigidBodyOfPlayer.transform.position + new Vector3(_dannyDirection * 0.5f, 0.3f, 0), Quaternion.identity);
            bomb.GetComponent<Rigidbody2D>().velocity = velo;
            timer = DateTime.Now;
        }
    }
}
