using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public InventoryItemData itemDataLLave;
    public GameObject LlaveMano;
    public GameObject prefabLlave;
    public InventoryItemData itemDataLinterna;
    public GameObject LinternaMano;
    public GameObject prefabLinterna;
    private string ultimaTeclaPulsada;
    public InventoryItemData ultimoItemSeleccionado;
    private GameObject ultimoGameObjectSeleccioando;
    private GameObject nuevo;
    private GameObject prefab;
    private bool linternaActiva = false;
 
    private void Start()
    {
        // Asegúrate de que tengas una referencia al InventorySystem
        inventorySystem = InventorySystem.Instance;
    }

    private void Update()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                if (inventorySystem.inventory[i - 1].data.Equals(itemDataLinterna))
                {
                    LinternaMano.SetActive(true);
                    LlaveMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataLinterna;
                    ultimoGameObjectSeleccioando = LinternaMano;
                    prefab = prefabLinterna;

                }
                else if (inventorySystem.inventory[i - 1].data.Equals(itemDataLLave))
                {
                    LlaveMano.SetActive(true);
                    LinternaMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataLLave;
                    ultimoGameObjectSeleccioando = LlaveMano;
                    prefab = prefabLlave;
                }
            }
        }
        if (Input.GetKeyDown("m") && ultimoGameObjectSeleccioando.activeSelf)
        {
            inventorySystem.Remove(ultimoItemSeleccionado);
            ultimoGameObjectSeleccioando.SetActive(false);
           // Vector3 posi= new Vector3(transform.position.x, 0.378f, transform.position.z );
            nuevo = Instantiate(prefab, transform.position, Quaternion.identity);
            nuevo.SetActive(true);
        }
        if (Input.GetKeyDown("x") && linternaActiva)
        {
            LinternaMano.transform.Find("Spot Light").gameObject.SetActive(false);
            linternaActiva = false;
        }
        else if (Input.GetKeyDown("x") && !linternaActiva)
        {
            LinternaMano.transform.Find("Spot Light").gameObject.SetActive(true);
            linternaActiva = true;
        }
    }
}
