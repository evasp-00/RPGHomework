using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    [SerializeField] private int CriticalChance = 20;

    public override void ApplyEffect(Character character)
    {
        if (Random.Range(0, 100) < CriticalChance)
        {
            character.health -= GetDamage() * 3;
        }
    }
}
