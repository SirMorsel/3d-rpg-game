using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensitivity = 2.0F;
    public float smoothing = 2.0F;

    public float minRot = -70.0F;
    public float maxRot = +70.0F;

    GameObject character;
	// Use this for initialization
	void Start ()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Clamp(smoothV.x, minRot, maxRot); // Doesn't working yet
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1F / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1F / smoothing);

        mouseLook += smoothV;
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
