using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarCaja : MonoBehaviour
{
    public GameObject Caja;
    public GameObject Tile;
    private Collider collider;
    public GameObject brazo;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision con: " + other.tag);
        if (other.gameObject.CompareTag("Caja") && !brazo.GetComponent<CogerCajas>().cajaCogida())
        {
            Caja = other.gameObject;
            Tile.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saliendo de colision con: " + other.tag);
        if (other.gameObject.CompareTag("Caja") && brazo.GetComponent<CogerCajas>().cajaCogida())
        {
            Caja = null;
            Tile.gameObject.SetActive(true);
        }
    }
}
