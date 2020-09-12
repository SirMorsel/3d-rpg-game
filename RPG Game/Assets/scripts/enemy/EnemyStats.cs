using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int level;
    public float health = 100.00F;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setDeath(); 
    }

    public void setDeath()
    {
        if (isDead)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerStats>().calcExperience(level);
            GameObject.Find(gameObject.name + "SpawnPoint").GetComponent<EnemyRespawn>().dead = true;

            Destroy(this.gameObject);
        }
    }

}
