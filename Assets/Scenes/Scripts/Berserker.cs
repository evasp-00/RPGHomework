using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int agressionGain = 10;

    public override int Attack()
    {
        agression += agressionGain; 
        return ActiveWeapon.GetDamage() + (agression / 10) - weakness + power;
    }

    public override void ResetCharacter()
    {
        health = maxHealth;
        Bleeding = 0;
        weakness = 0;
        agression = 0;
    }
}
