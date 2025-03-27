using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public int bleeding;
    public int weakness;
    public int power;

    [SerializeField] protected Weapon activeWeapon;


    private void Awake()
    {
        resetCharacter();
    }

    public void resetCharacter()
    {
        health = maxHealth;
        bleeding = 0;
        weakness = 0;
        power = 0;
    }


    public Weapon ActiveWeapon
    { 
        get { return activeWeapon; }    
    }

    public virtual int Attack()
    {
        return activeWeapon.GetDamage();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(name + " health before hit: " + health);
        health -= damage - weakness + power;
        Debug.Log(name + " health after hit: " + health);
    }

    public void TakeDamage(Weapon weapon)
    {
        Debug.Log(name + " health before hit: " + health);
        health -= weapon.GetDamage() - weakness + power;
        weapon.ApplyEffect(this);
        Debug.Log(name + " health after hit: " + health);
    }

    public void EndRound()
    {

        Debug.Log(name + " weakness: " + weakness);

        if (weakness > 0)
        {
            weakness--;
        }

        int bleed = bleeding / 5;

        if (bleeding < 5)
        {
            bleed = bleeding;
        }

        Debug.Log(name + " blead: " + bleed);

        health -= bleed;
        bleeding -= bleed;

    }

}

  
