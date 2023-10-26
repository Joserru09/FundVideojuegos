using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //MEUVE LA CAMARA DONDE ESTÁ EL JUGADOR
    public Transform cameraPosition;
   void Update()
    {
        transform.position=cameraPosition.position;    
    }
}
