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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Caja"))
        {
            Tile.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("CajaCogida"))
        {
            Caja = other.gameObject;
            Tile.gameObject.SetActive(true);
        }
    }
}
