using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] TMP_Text playerName, playerHealth, enemyName, enemyHealth, level, xp;

    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource healSound;


    [SerializeField] private Image enemySprite;

    [SerializeField] private GameObject gameOver;

    [SerializeField] private TextMeshProUGUI healButton;

    public GameManager instance;

    public int playerLevel = 0;

    public int playerXP = 0;
    private int xpGoal = 0;


    public int healCD;

    private int currentEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        getEnemy();
        RefreshUI();
        xpGoal = (playerLevel + 1) * 5;
        healCD = 0;

        gameOver.SetActive(false);
    }

    private void getEnemy()
    {
        currentEnemy = Random.Range(0, enemies.Length);
    }

    public void DoRound()
    {

        attackSound.pitch = Random.Range(0.8f, 1.1f);
        attackSound.Play();

        //int playerDamage = player.Attack();
        //enemy.TakeDamage(playerDamage);
        //Debug.Log("player name: " + player.CharName);
        enemies[currentEnemy].TakeDamage(player.ActiveWeapon);
        enemies[currentEnemy].TakeDamage(player.power / 3);
        int enemyDamage = enemies[currentEnemy].Attack();
        player.TakeDamage(enemyDamage);

        player.EndRound();
        enemies[currentEnemy].EndRound();

        if (enemies[currentEnemy].health <= 0)
        {
            enemies[currentEnemy].maxHealth += enemies[currentEnemy].healthGain;
            enemies[currentEnemy].ResetCharacter();
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

        healCD--;

        if (player.health <= 0)
        {
            gameOver.SetActive(true);
        }

    }

    public void HealSpell()
    {
        if (healCD <= 0 && player.health < player.maxHealth)
        {
            healSound.Play();
            player.health += Random.Range(0 + player.power, 10 + player.power);
            if (player.health > player.maxHealth) 
            {
                player.health = player.maxHealth;
            }
            healCD = Random.Range(7, 15);
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (healCD <= 0)
        {
            healButton.color = Color.white;
        }
        else
        {
            healButton.color = Color.black;
        }

        playerName.text = "Player: " + player.CharName;
        enemyName.text = enemies[currentEnemy].name;
        playerHealth.text = "Health: " + player.maxHealth.ToString() + "/" + player.health.ToString();
        enemyHealth.text = "Health: " + enemies[currentEnemy].maxHealth + "/" + enemies[currentEnemy].health.ToString();
        level.text = "Level: " + playerLevel.ToString();
        xp.text = "XP: " + xpGoal.ToString() + "/" + playerXP.ToString();


        enemySprite.sprite = enemies[currentEnemy].getSprite();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
