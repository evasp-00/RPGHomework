using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikinWeapon : Weapon
{
    [SerializeField] private int bleedAmount = 10;

    public override void ApplyEffect(Character character)
    {
        character.Bleeding += bleedAmount;
    }
}
