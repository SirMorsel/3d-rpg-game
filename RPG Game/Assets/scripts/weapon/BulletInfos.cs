using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfos : MonoBehaviour
{

    public float lifeTime = 200F;
    [HideInInspector]
    public float damage;

   // public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= 0)
        {
           Destroy(this.gameObject);
        }

        lifeTime--;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!other.gameObject.GetComponent<EnemyStats>().isDead)
            {

                other.gameObject.GetComponent<EnemyStats>().health -= damage;

                if (other.gameObject.GetComponent<EnemyStats>().health <= 0)
                {
                    other.gameObject.GetComponent<EnemyStats>().isDead = true;                
                }
            }
        }
        Destroy(this.gameObject);
    }
}
