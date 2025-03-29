using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected int agression = 10;
    [SerializeField] private Sprite sprite;
    [SerializeField] public int healthGain = 0;

    public Sprite getSprite()
    {
        return sprite;
    }
}
