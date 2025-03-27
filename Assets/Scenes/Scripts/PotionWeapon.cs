using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionWeapon : Weapon
{
    [SerializeField] private int weaknessAmount = 1;

    public override void ApplyEffect(Character character)
    {
        character.weakness += weaknessAmount;
    }
}
