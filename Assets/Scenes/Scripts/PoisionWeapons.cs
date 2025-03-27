using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionWeapons : Weapon
{
    [SerializeField] private int poisionDamage = 2;

    public override void ApplyEffect(Character character)
    {
        character.TakeDamage(poisionDamage);
        Debug.Log(character.name + " took " + poisionDamage + " poison damage");
    }
}
