using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SystemDoor : MonoBehaviour
{
    public bool doorOpen = false;   //Ver si la puerta está abierta o cerrada
    public float doorOpenAngle = 95f; //Angulo de la puerta cuando está abierta
    public float doorCloseAngle = 0.0f; //Angulo de la puerta cuando está cerrada
    public float rotSpeed = 3.0f;  //Velocidad de rotacion
    public GameObject door;
    public InventorySystem inventorySystem;
    public InputManager hand;
    public InventoryItemData inventoryItemData;
    public GameObject TextNecesitoLlave;
    public GameObject TextQparaAbrir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, targetRotation, rotSpeed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Door").GetComponent<Collider>().enabled = false;
            GameObject.FindGameObjectWithTag("Door").GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, targetRotation2, rotSpeed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Door").GetComponent<Collider>().isTrigger = false;
            GameObject.FindGameObjectWithTag("Door").GetComponent<Collider>().enabled = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.CompareTag("Door"))
                TextNecesitoLlave.SetActive(true);
            

             if (other.gameObject.CompareTag("Door") && hand.ultimoItemSeleccionado.itemName.Equals(inventoryItemData.itemName) && inventorySystem.dameInst().HasItem("Llave"))
            {
            TextNecesitoLlave.SetActive(false);
            TextQparaAbrir.SetActive(true);
                if (Input.GetKey("q"))
                {
                    TextQparaAbrir.SetActive(false) ;
                    doorOpen = true;
                    yield return new WaitForSecondsRealtime(3.0f);
                    doorOpen = false;
                }

            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            TextNecesitoLlave.SetActive(false);
            TextQparaAbrir.SetActive(false);

        }
    }
}
