using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0F;
    public float runSpeed = 10.0F;
    public float jumpForce = 8.0F;
    public float gravity = 30.0F;
    private Vector3 moveDirection = Vector3.zero;

    public bool isShooting;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        reloadWeapon();
    }

    public void movement()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= runSpeed;
            }
            else
            {
                moveDirection *= walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
    }

    public void reloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponentInChildren<WeaponStats>().manualReaload();
        }
    }

    public void fire()
    {
        GetComponentInChildren<WeaponStats>().getMag();

        if (GetComponentInChildren<WeaponStats>().currrentBulletsInMag > 0 && canShoot == true)
        {
            isShooting = true;
            GetComponentInChildren<WeaponStats>().getAudio();
            float projectile_speed = GetComponentInChildren<WeaponStats>().bulletSpeed;
           // Debug.Log("Nach Schuss " + GetComponentInChildren<WeaponStats>().currrentBulletsInMag);

            GameObject bullet = Instantiate(GetComponentInChildren<WeaponStats>().bulletPrefab,
                                            GetComponentInChildren<WeaponStats>().bulletSpawn.position,
                                            GetComponentInChildren<WeaponStats>().bulletSpawn.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * projectile_speed * Time.deltaTime;
            bullet.GetComponent<Rigidbody>().AddRelativeForce((Vector3.forward * 12) * projectile_speed);
            bullet.GetComponent<BulletInfos>().damage = GetComponentInChildren<WeaponStats>().damage;
            bullet.GetComponent<BulletInfos>().lifeTime = GetComponentInChildren<WeaponStats>().bulletLifeTime;
        }
    }
}
