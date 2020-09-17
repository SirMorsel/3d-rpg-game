using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationSlots : MonoBehaviour
{
    GameObject formationHolder;
    public int countFormationSLots = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countFormationSLots; i++)
        {
            formationHolder = new GameObject("formationSlot" + i);
            // in case you want the new gameobject to be a child
            // of the gameobject that your script is attached to
            formationHolder.transform.parent = this.gameObject.transform;
            formationHolder.transform.localPosition = new Vector3(setInitPosition(i), 0, setInitPosition(i));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float setInitPosition(int positionIndex)
    {
        if (positionIndex % 2 == 0)
        {
            return 2.0f;
        }
        else
        {
            return -2.0f;
        }
    }
}
