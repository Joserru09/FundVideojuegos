using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerCajas : MonoBehaviour
{

    //public GameObject handPoint;

    public GameObject pickedObject = null;


    // Update is called once per frame
    void Update()
    {
        if (pickedObject != null)
        {

            if (Input.GetKey("f") && pickedObject != null)
            {
                pickedObject.tag = "Caja";
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }

        }
    }

    public GameObject getPickedObject ()
    { return pickedObject; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Caja") )
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                pickedObject = other.gameObject;
                pickedObject.tag = "CajaCogida";
                other.gameObject.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    public Boolean cajaCogida()
    {
        return pickedObject != null;    
    }
}
