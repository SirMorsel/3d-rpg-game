using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public string weaponName;
    public int rarity;
    public string weaponType = "";
    public string ammoType = "";
    public float damage;
    public float fireRate;
    public float bulletSpeed = 1000.0F;
    public int magCapacity;         // Max Amount of Bullets in one Mag
    public int currrentBulletsInMag;
    public int maxAmountOfBullets;  // Max Number of Bullets

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletLifeTime = 200F;

    AudioSource source;
    public AudioClip audioShoot;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getMag()
    {
        bool isShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isShooting;
        if (isShooting == true && currrentBulletsInMag > 0)
        {
            currrentBulletsInMag--;
        }
        else if (currrentBulletsInMag == 0)
        {
            if (maxAmountOfBullets >= magCapacity)
            {
                maxAmountOfBullets -= magCapacity;
                currrentBulletsInMag = magCapacity;
            }
        }
        
        return currrentBulletsInMag;
    }

    public void manualReaload()
    {
        if (currrentBulletsInMag < magCapacity)
        {
            int lostBullets = magCapacity - currrentBulletsInMag;

            if (maxAmountOfBullets > lostBullets)
            {
                maxAmountOfBullets -= lostBullets;
                currrentBulletsInMag += lostBullets;
                Debug.Log("Test totalBullets: " + maxAmountOfBullets + " Test lostBullets: " + lostBullets);
            }
            else
            {
                currrentBulletsInMag += maxAmountOfBullets;
                maxAmountOfBullets = 0;
                Debug.Log("Test clipMag: " + currrentBulletsInMag + " Test totalBullets: " + maxAmountOfBullets);
            }
        }
        else
        {
            Debug.Log("Nothing to reload");
        }
    }

    public void getAudio()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(audioShoot, 1);
    }
}
