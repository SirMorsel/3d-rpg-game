using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public bool Death;
    public float Timer;
    public float Cooldown;
    public GameObject Enemy;
    public string EnemyName;
    GameObject LastEnemy;

    // Use this for initialization
    void Start()
    {
        Death = true;
        this.gameObject.name = EnemyName + "SpawnPoint";
    }

    // Update is called once per frame
    void Update()
    {
        if (Death == true)
        {
            Timer += Time.deltaTime;
        }
 
        if (Timer >= Cooldown)
        {
            //It will create a new Enemy of the same class, at this position.
            Enemy.transform.position = transform.position;

            Instantiate(Enemy);
            LastEnemy = GameObject.Find(Enemy.name + "(Clone)");
            LastEnemy.name = EnemyName;
            Death = false;
            Timer = 0;
        }
    }
}
