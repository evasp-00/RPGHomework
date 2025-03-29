using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class Player : Character
{
    [SerializeField] private string charName;

    [SerializeField] private Weapon[] weapons;
    private int selectedWeapon;
    [SerializeField] private TextMeshProUGUI[] buttonText;


    public string CharName
    {
        get { return charName; }
    }

    private void Start()
    {
        selectedWeapon = 0;
        SwitchWeapon(selectedWeapon);
    }

    public void SwitchWeapon(int weapon)
    {
        buttonText[selectedWeapon].color = Color.black;
        activeWeapon = weapons[weapon];
        selectedWeapon = weapon;
        buttonText[selectedWeapon].color = Color.white;
    }

    public void LevelUp()
    {
        maxHealth += 10;
        int toHeal = 0;
        if (health < maxHealth)
        {
            toHeal = maxHealth - health;
        }
        health += toHeal;
        power++;
    }
}
