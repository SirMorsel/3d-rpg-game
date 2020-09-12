using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollower : MonoBehaviour
{
    public GameObject player;
    public GameObject follower;
    public float targetDistance;
    public float allowedDistance = 10;
    public float followSpeed;
    public RaycastHit shot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    public void follow()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = 0.01f;
                //  follower.GetComponent<Animation>().Play("ANIMATION_NAME_RUNNING"); // RUN Animation
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
                // follower.GetComponent<Animation>().Play("ANIMATION_NAME_IDLE"); // IDLE Animation
            }
        }
    }
}
