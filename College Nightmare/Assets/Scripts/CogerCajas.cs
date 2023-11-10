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
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }

        }
    }

    public GameObject getPickedObject ()
    { return pickedObject; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto") )
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.gameObject.transform.SetParent(this.gameObject.transform);

                pickedObject = other.gameObject;
            }
        }
    }
}
