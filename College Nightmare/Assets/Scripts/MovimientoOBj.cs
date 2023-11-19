using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOBj : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidadH;
    public float velocidadV;


    float MovimientoH;
    float MovimientoV;

    void Start()
    {
        
    }

    // Update is called once per frame
   private void OnMouseDrag()
    {
        MovimientoH -= velocidadH * Input.GetAxis("Mouse X");
        MovimientoV += velocidadV * Input.GetAxis("Mouse Y");

        if(Input.GetMouseButton(0)) { 
        transform.eulerAngles = new Vector3 (MovimientoV, MovimientoH, 0f);
        }
    }
}
