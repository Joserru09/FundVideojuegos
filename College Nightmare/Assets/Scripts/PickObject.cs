using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{

    public GameObject handPoint;

    private GameObject pickedObject = null;
    //public InventoryItemData itemData;



    // Update is called once per frame
    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("f") && pickedObject!=null) {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
              //  if (pickedObject.tag == "ObjetoLlave")
               //     pickedObject.transform.localScale = pickedObject.transform.localScale/5f;
             //   pickedObject.gameObject.transform.SetParent(null);
                
                pickedObject = null;
                //OnHandleHandOff();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("Objeto") )
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent <Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;
              //  if(other.tag == "ObjetoLlave")
                //    other.transform.localScale*= 5f;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
                //OnHandlePickUp();
            }
        }
    }
   /* private void OnHandlePickUp()
    {

        InventorySystem.Instance.Add(itemData);
    }

    private void OnHandleHandOff()
    {

        InventorySystem.Instance.Remove(itemData);

    }*/
}
