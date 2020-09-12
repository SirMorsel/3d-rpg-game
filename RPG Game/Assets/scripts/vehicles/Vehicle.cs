using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    public float speed = 100.0F;
    public float rotateSpeed = 5.0F;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public GameObject bulletPrefabMG;
    public Transform bulletSpawnMG;

    AudioSource source;
    public AudioClip audioMain;
    public AudioClip audioMG;

    public float bulletSpeed = 1000.0F;
    public float reloadTime = 5.0F;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * rotateSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, -z);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            Debug.Log("Fire1-Button");
        }
        if (Input.GetButton("Fire2"))
        {
            FireMG();
            Debug.Log("Fire2-Button");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump-Button");
        }
    }

    public void Fire()
    {
        source = GetComponent<AudioSource>();
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        
            // Destroy the bullet after 0.2 seconds
            Destroy(bullet, 0.2f);
            source.PlayOneShot(audioMain, 1);
           
    }

    public void FireMG()
    {
        source = GetComponent<AudioSource>();
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
                bulletPrefabMG,
                bulletSpawnMG.position,
                bulletSpawnMG.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 0.2 seconds
        Destroy(bullet, 0.2f);
        source.PlayOneShot(audioMG, 1);

    }


}
