using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Character character;
    [SerializeField] TMP_Text playerName, playerHealth, enemyName, enemyHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshUI();
    }

    public void DoRound()
    {
        //int playerDamage = player.Attack();
        //enemy.TakeDamage(playerDamage);
        //Debug.Log("player name: " + player.CharName);
        enemy.TakeDamage(player.ActiveWeapon);
        int enemyDamage = enemy.Attack();
        player.TakeDamage(enemyDamage);
        RefreshUI();

    }

    public void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text = "Health: " + player.health.ToString();
        enemyHealth.text = "Health: " + enemy.health.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
