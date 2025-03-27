using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] TMP_Text playerName, playerHealth, enemyName, enemyHealth, level, xp;

    [SerializeField] private Image enemySprite;

    public GameManager instance;

    public int playerLevel = 0;

    public int playerXP = 0;
    private int xpGoal = 0;


    public int round;

    private int currentEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        round = 0;   
        getEnemy();
        RefreshUI();
        xpGoal = (playerLevel + 1) * 5;
    }

    private void getEnemy()
    {
        currentEnemy = Random.Range(0, enemies.Length);
    }

    public void DoRound()
    {
        //int playerDamage = player.Attack();
        //enemy.TakeDamage(playerDamage);
        //Debug.Log("player name: " + player.CharName);
        enemies[currentEnemy].TakeDamage(player.ActiveWeapon);
        int enemyDamage = enemies[currentEnemy].Attack();
        player.TakeDamage(enemyDamage);

        player.EndRound();
        enemies[currentEnemy].EndRound();

        if (enemies[currentEnemy].health <= 0)
        {
            enemies[currentEnemy].resetCharacter();
            getEnemy();
            playerXP += 5;
        }

        if (playerXP >= xpGoal)
        {
            playerLevel++;
            playerXP = 0;

            xpGoal = (playerLevel + 1) * 5;

            player.LevelUp();
        }

        RefreshUI();

        round++;

    }

    public void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemies[currentEnemy].name;
        playerHealth.text = "Health: " + player.health.ToString();
        enemyHealth.text = "Health: " + enemies[currentEnemy].health.ToString();
        level.text = "Level: " + playerLevel.ToString();
        xp.text = "XP: " + playerXP.ToString() + "/" + xpGoal.ToString();


        enemySprite.sprite = enemies[currentEnemy].getSprite();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
