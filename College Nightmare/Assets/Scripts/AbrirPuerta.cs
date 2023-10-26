using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{

    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó es el jugador (por ejemplo, con una etiqueta "Player")
        if (other.tag=="Player")
        {
            Debug.Log("ATRAVESADO");

            // Verificar si el jugador presionó la tecla "Q"
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
                // Cambiar la posición del objeto al valor de newPosition
                Quaternion newRotation = door.transform.rotation;
                newRotation.y = 90f;
                door.transform.rotation = newRotation;

                Vector3 newPosition = door.transform.position;
                newPosition.x = 39.28f;
                newPosition.y = 45.29133f;
                newPosition.z = -3.23f;
                door.transform.position = newPosition;
            //}
        }
    }
}


