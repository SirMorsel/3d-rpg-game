using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {
    // Script must be in Vehicle
    public GameObject vehicle;
    public GameObject player;
    public GameObject playerBackup;

    private bool inVehicle = false;
    Vehicle vehicleScrip;
    GameObject guiObj;
    AudioSource source;
    public AudioClip audio;

    public Camera mainCam;
    public Camera driveCam;

	// Use this for initialization
	void Start ()
    {
        mainCam.enabled = true;
        driveCam.enabled = false;
        vehicleScrip = GetComponent<Vehicle>();
        vehicleScrip.enabled = false;
        source = GetComponent<AudioSource>();
        // guiObj = GameObject.Find("PressE");
        // guiObj.SetActive(false);
        playerBackup.SetActive(false);
       // guiObj.SetActive(false);
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            player.SetActive(true);
            player.transform.parent = null;
            playerBackup.SetActive(false);
            vehicleScrip.enabled = false;
            inVehicle = false;
            mainCam.enabled = true;
            driveCam.enabled = false;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
          //  guiObj.SetActive(true);
        }

        if (other.gameObject.tag == "Player" && inVehicle == false && Input.GetKey(KeyCode.E))
        {
           // source.PlayOneShot(audio, 1);
          //  guiObj.SetActive(false);
            playerBackup.SetActive(true);
            player.SetActive(false);
            player.transform.parent = vehicle.transform;
            vehicleScrip.enabled = true;
            inVehicle = true;
            mainCam.enabled = false;
            driveCam.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          //  guiObj.SetActive(false);
        }
    }

}
