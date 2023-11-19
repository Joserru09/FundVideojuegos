using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisarObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject notaVisual;
    public GameObject objVisual;
    public GameObject camaraVisual;
    public GameObject objEnEscena;
    public GameObject camaraJuego;
    public GameObject luz;
    public bool activa;
    

    // Update is called once per frame
    void Update()
    {
        luz.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Tab) && activa) {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camaraJuego.SetActive(false);
            notaVisual.SetActive(true);
            objVisual.SetActive(true);
            camaraVisual.SetActive(true);
            objEnEscena.SetActive(false);
           
        }
        if (Input.GetKeyDown(KeyCode.Escape ) && activa)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            camaraJuego.SetActive(true);
            notaVisual.SetActive(false);
            objVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activa = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            activa = false;
            notaVisual.SetActive(false);
            notaVisual.SetActive(false);
            objVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }
    }
}
