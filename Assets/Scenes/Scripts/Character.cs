using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private int bleeding;
    public int weakness;
    public int power;

    [SerializeField] protected Weapon activeWeapon;


    private void Awake()
    {
        ResetCharacter();
    }

    public virtual void ResetCharacter()
    {
        health = maxHealth;
        bleeding = 0;
        weakness = 0;
        power = 0;
    }

    public int Bleeding
    {
        get { return bleeding; }
        set
        {
            if (value < 0)
            { 
                bleeding = 0;
            }
            else
            {
                bleeding = value;
            }
        }
    }

    public Weapon ActiveWeapon
    { 
        get { return activeWeapon; }    
    }

    public virtual int Attack()
    {
        int damage = activeWeapon.GetDamage() - weakness + power;
        if (damage < 0) { damage = 0; }
        return damage;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(name + " health before hit: " + health);
        health -= damage;
        Debug.Log(name + " health after hit: " + health);
    }

    public void TakeDamage(Weapon weapon)
    {
        Debug.Log(name + " health before hit: " + health);
        health -= weapon.GetDamage();
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

  
