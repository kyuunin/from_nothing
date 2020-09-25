using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int HealValue;
    void Heal(int lives)
    {
        ValuesStore.CommonValues.LivesOfPlayer += lives;
        if(ValuesStore.CommonValues.LivesOfPlayer > DamageValues.DefaultLivesOfPlayer)
        {
            ValuesStore.CommonValues.LivesOfPlayer = DamageValues.DefaultLivesOfPlayer;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        Heal(HealValue);
        Destroy(gameObject);
    }
}
