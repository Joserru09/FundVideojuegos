using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CajaDetector;

public class PlayerController : MonoBehaviour
{
    public GameObject playerAvatar;
    public Tile currentTile;
    public GameObject detectorCaja;

    public Tile leftTile;
    public Tile rightTile;
    public Tile forwardTile;
    public Tile backwardTile;

    public Caja leftCaja;
    public Caja rightCaja;
    public Caja forwardCaja;
    public Caja backwardCaja;

    public float speed;
    public float rotationSpeed;
    public bool moving;
    public bool rotating;
    public Vector3 movingDirection;
    public Vector3 targetPosition;
    public float distanceToTarget;
    public GameObject brazo;
    public string mirandoA;
    public Camera camaraCajas;
    public Canvas canvas;

    void Start()
    {
        mirandoA = "UP";
        //camaraCajas.enabled = false;


        camaraCajas.enabled = false;
        camaraCajas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        if (moving)
        {
            PerformMovement();

        }
        CogerCajas cc = brazo.GetComponent<CogerCajas>();
        if (rotating && cc.pickedObject == null)
        {
            RotateTowardsDirection();
        }
    }

    void ReadInput()
    {
        CogerCajas cc = brazo.GetComponent<CogerCajas>();
        detectorCajasJugador dCJ = detectorCaja.GetComponent<detectorCajasJugador>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (inputDirection != Vector3.zero && cc.pickedObject == null)
        {
            movingDirection = inputDirection;
            rotating = true;
            mirandoA = GetDirectionFromInput(inputDirection);
            Vector3 nueva = gameObject.transform.position;
            switch (mirandoA)
            {
                case "UP":
                    nueva.z = nueva.z + 2;
                    dCJ.transform.position = nueva;
                    break;
                case "DOWN":
                    nueva = gameObject.transform.position;
                    nueva.z = nueva.z - 2;
                    dCJ.transform.position = nueva;
                    break;
                case "LEFT":
                    nueva = gameObject.transform.position;
                    nueva.x = nueva.x - 2;
                    dCJ.transform.position = nueva;
                    break;
                case "RIGHT":
                    nueva = gameObject.transform.position;
                    nueva.x = nueva.x + 2;
                    dCJ.transform.position = nueva;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (cc.pickedObject != null && leftTile != null && leftCaja == null && mirandoA.Equals("LEFT") && dCJ.puedeAndar)
            {
                MoveToPosition(leftTile.GetTilePosition());
                mirandoA = "LEFT";
            }
            else if (cc.pickedObject != null && leftTile != null && leftCaja == null && mirandoA.Equals("RIGHT"))
            {
                MoveToPosition(leftTile.GetTilePosition());
                mirandoA = "RIGHT";
            }
            else if (cc.pickedObject == null && leftTile != null && leftCaja == null)
            {
                MoveToPosition(leftTile.GetTilePosition());
                mirandoA = "LEFT";
                Vector3 nueva = gameObject.transform.position;

                nueva.x = nueva.x - 2;
                dCJ.transform.position = nueva;

            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (cc.pickedObject != null && rightTile != null && rightCaja == null && mirandoA.Equals("RIGHT") && dCJ.puedeAndar)
            {
                MoveToPosition(rightTile.GetTilePosition());
                mirandoA = "RIGHT";
            }
            else if (cc.pickedObject != null && rightTile != null && rightCaja == null && mirandoA.Equals("LEFT"))
            {
                MoveToPosition(rightTile.GetTilePosition());
                mirandoA = "LEFT";
            }
            else if (cc.pickedObject == null && rightTile != null && rightCaja == null)
            {
                MoveToPosition(rightTile.GetTilePosition());
                mirandoA = "RIGHT";
                Vector3 nueva = gameObject.transform.position;

                nueva.x = nueva.x + 2;
                dCJ.transform.position = nueva;
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (cc.pickedObject != null && forwardTile != null && forwardCaja == null && mirandoA.Equals("UP") && dCJ.puedeAndar)
            {
                MoveToPosition(forwardTile.GetTilePosition());
                mirandoA = "UP";
            }
            else if (cc.pickedObject != null && forwardTile != null && forwardCaja == null && mirandoA.Equals("DOWN"))
            {
                MoveToPosition(forwardTile.GetTilePosition());
                mirandoA = "DOWN";
            }
            else if (cc.pickedObject == null && forwardTile != null && forwardCaja == null)
            {
                MoveToPosition(forwardTile.GetTilePosition());
                mirandoA = "UP";
                Vector3 nueva = gameObject.transform.position;

                nueva.z = nueva.z + 2;
                dCJ.transform.position = nueva;

            }


        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (cc.pickedObject != null && backwardTile != null && backwardCaja == null && mirandoA.Equals("UP"))
            {
                MoveToPosition(backwardTile.GetTilePosition());
                mirandoA = "UP";
            }
            else if (cc.pickedObject != null && backwardTile != null && backwardCaja == null && mirandoA.Equals("DOWN") && dCJ.puedeAndar)
            {
                MoveToPosition(backwardTile.GetTilePosition());
                mirandoA = "DOWN";
            }
            else if (cc.pickedObject == null && backwardTile != null && backwardCaja == null)
            {
                MoveToPosition(backwardTile.GetTilePosition());
                mirandoA = "DOWN";
                Vector3 nueva = gameObject.transform.position;

                nueva.z = nueva.z - 2;
                dCJ.transform.position = nueva;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && camaraCajas.enabled==true)
        {
            //SceneManager.LoadScene("TileMovement");
        }


    }
    string GetDirectionFromInput(Vector3 inputDirection)
    {
        float angle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;

        if (angle > -45 && angle <= 45)
        {
            return "UP";
        }
        else if (angle > 45 && angle <= 135)
        {
            return "RIGHT";
        }
        else if (angle > 135 || angle <= -135)
        {
            return "DOWN";
        }
        else
        {
            return "LEFT";
        }
    }
    void PerformMovement()
    {
        transform.position += movingDirection * speed * Time.deltaTime;
        float currentDistance = (targetPosition - transform.position).magnitude;
        if (distanceToTarget < currentDistance)
        {
            moving = false;
            transform.position = targetPosition;
        }
        else
        {
            distanceToTarget = currentDistance;
        }
    }

    void RotateTowardsDirection()
    {
        Vector3 newRotation = (Vector3.RotateTowards(playerAvatar.transform.forward, movingDirection, rotationSpeed * Time.deltaTime, 1f));
        if ((playerAvatar.transform.eulerAngles - newRotation).magnitude < 0.2f)
        {
            rotating = false;
            playerAvatar.transform.rotation = Quaternion.LookRotation(movingDirection);
        }
        else
        {
            playerAvatar.transform.rotation = Quaternion.LookRotation(newRotation);
        }

    }

    void MoveToPosition(Vector3 position)
    {
        targetPosition = position;
        movingDirection = (position - transform.position);
        distanceToTarget = movingDirection.magnitude;
        movingDirection = movingDirection.normalized;
        moving = true;
        rotating = true;
    }

    public void SetLeftTile(Tile tile)
    {
        leftTile = tile;
    }
    public void SetRightTile(Tile tile)
    {
        rightTile = tile;
    }

    public void SetForwardTile(Tile tile)
    {
        forwardTile = tile;
    }
    public void SetBackwardTile(Tile tile)
    {
        backwardTile = tile;
    }
    public void SetCurrentTile(Tile tile)
    {
        currentTile = tile;
    }

    //CAJAS
    public void SetLeftCaja(Caja caja)
    {
        leftCaja = caja;
    }
    public void SetRightCaja(Caja caja)
    {
        rightCaja = caja;
    }

    public void SetForwardCaja(Caja caja)
    {
        forwardCaja = caja;
    }
    public void SetBackwardCaja(Caja caja)
    {
        backwardCaja = caja;
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("FIN"))
        {
            //if (Input.GetKeyDown(KeyCode.R))
            //{
                canvas.gameObject.SetActive(true);
                camaraCajas.enabled = false;
                camaraCajas.gameObject.SetActive(false);
            //}
        }
    }
}



