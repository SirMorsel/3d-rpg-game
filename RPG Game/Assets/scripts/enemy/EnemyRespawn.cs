using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public bool dead;
    public float timer;
    public float cooldown;
    public GameObject enemy;
    public string enemyName;
    GameObject lastEnemy;

    // Use this for initialization
    void Start()
    {
        dead = true;
        this.gameObject.name = enemyName + "SpawnPoint";
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            timer += Time.deltaTime;
        }
 
        if (timer >= cooldown)
        {
            //It will create a new Enemy of the same class, at this position.
            enemy.transform.position = transform.position;

            Instantiate(enemy);
            lastEnemy = GameObject.Find(enemy.name + "(Clone)");
            lastEnemy.name = enemyName;
            dead = false;
            timer = 0;
        }
    }
}
