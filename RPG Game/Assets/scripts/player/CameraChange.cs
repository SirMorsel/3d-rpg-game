using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;
    public int camMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode += 1;
            }
            StartCoroutine(CamChange());
        }  
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01F);
        if (camMode == 0)
        {
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        if (camMode == 1)
        {
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
        
    }
}
