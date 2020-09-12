using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Player Infos
    public int id = 0;
    public string playerName = "Playername";
    public int level = 1;
    // Health
    public float playerMaxHealth = 100.00F;
    public float playerHealth;
    // Other Stats
    public double playerExperience = 0;
    private const int baseExperience = 400;
    public double neededExpForNextLv = baseExperience;
    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        setLevelUp();
    }

    public float calcHealthBar()
    {
        return playerHealth / playerMaxHealth;
    }

    public void getDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            isDead = true;
        }
    }

    public void increasHealth(int healPoints)
    {
        playerHealth += healPoints;

        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }

    public void calcExperience(int enemieLv)
    {
        playerExperience += ((enemieLv / (level * 0.995)) + 0.085) * 40;
    }

    public void setLevelUp()
    {
        if (playerExperience >= neededExpForNextLv)
        {
            level++;
            neededExpForNextLv = neededExpForNextLv * 1.5;
            playerExperience = 0;
        }
    }

    public double calcExpBar()
    {
        return playerExperience / neededExpForNextLv;
    }
}
