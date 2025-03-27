using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;

    [SerializeField] private Weapon[] weapons;



    public string CharName
    {
        get { return charName; }
    }

    public void SwitchWeapon(int weapon)
    {
        activeWeapon = weapons[weapon];
    }

    public void LevelUp()
    {
        maxHealth += 5;
        health = maxHealth;
        power++;
    }
}
