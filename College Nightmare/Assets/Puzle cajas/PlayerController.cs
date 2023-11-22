using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        mirandoA ="UP";
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
        if (rotating && cc.pickedObject==null)
        {
            RotateTowardsDirection();
        }


    }

    void ReadInput()
    {
        CogerCajas cc = brazo.GetComponent<CogerCajas>();
        detectorCajasJugador dCJ = detectorCaja.GetComponent<detectorCajasJugador>();
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
    }
    /*
    void ReadInput() {
            CogerCajas cc = brazo.GetComponent<CogerCajas>();
        
            if (Input.GetKeyDown(KeyCode.A))
            {   
                if (cc.pickedObject != null && leftTile != null && leftCaja == null && (mirandoA.Equals("RIGHT")||mirandoA.Equals("LEFT")))
                {
                    MoveToPosition(leftTile.GetTilePosition());
                    mirandoA = "LEFT";
                }
                else if(cc.pickedObject == null && leftTile != null && leftCaja == null) { 
                    MoveToPosition(leftTile.GetTilePosition());
                    mirandoA = "LEFT";
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (cc.pickedObject != null && rightTile != null && rightCaja == null && (mirandoA.Equals("RIGHT") || mirandoA.Equals("LEFT")))
                {
                    MoveToPosition(rightTile.GetTilePosition());
                    mirandoA = "RIGHT";
                }
                else if (cc.pickedObject == null && rightTile != null && rightCaja == null) { 
                    MoveToPosition(rightTile.GetTilePosition());
                    mirandoA = "RIGHT";
                }
        }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (cc.pickedObject != null && forwardTile != null && forwardCaja == null && (mirandoA.Equals("UP") || mirandoA.Equals("DOWN")))
                {
                    MoveToPosition(forwardTile.GetTilePosition());
                    mirandoA = "UP";
                }
                else if (cc.pickedObject == null && forwardTile != null && forwardCaja == null) { 
                    MoveToPosition(forwardTile.GetTilePosition());
                    mirandoA = "UP";
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (cc.pickedObject != null && backwardTile != null && backwardCaja == null && (mirandoA.Equals("UP") || mirandoA.Equals("DOWN")))
                {
                    MoveToPosition(backwardTile.GetTilePosition());
                    mirandoA = "DOWN";
                }
                else if (cc.pickedObject == null && backwardTile != null && backwardCaja == null) { 
                    MoveToPosition(backwardTile.GetTilePosition());
                    mirandoA = "DOWN";
                }
            }
    } 
    */
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
        Vector3 newRotation = (Vector3.RotateTowards(playerAvatar.transform.forward, movingDirection, rotationSpeed*Time.deltaTime, 1f));
        if ((playerAvatar.transform.eulerAngles-newRotation).magnitude<0.2f)
        {
            rotating = false;
            playerAvatar.transform.rotation = Quaternion.LookRotation(movingDirection);
        }
        else
        {
            playerAvatar.transform.rotation = Quaternion.LookRotation(newRotation);
        }

    }

    public void MoveToPosition(Vector3 position)
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

}
