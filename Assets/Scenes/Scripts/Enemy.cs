using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected int agression = 10;
    [SerializeField] private Sprite sprite;

    public Sprite getSprite()
    {
        return sprite;
    }
}
