﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerAvatar;
    public Tile currentTile;

    public Tile leftTile;
    public Tile rightTile;
    public Tile forwardTile;
    public Tile backwardTile;

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

    void ReadInput() {
            CogerCajas cc = brazo.GetComponent<CogerCajas>();
        
            if (Input.GetKeyDown(KeyCode.A))
            {   
                if (cc.pickedObject != null && leftTile != null && (mirandoA.Equals("RIGHT")||mirandoA.Equals("LEFT")))
                {
                    MoveToPosition(leftTile.GetTilePosition());
                    mirandoA = "LEFT";
                }
                else if(cc.pickedObject == null && leftTile != null) { 
                    MoveToPosition(leftTile.GetTilePosition());
                    mirandoA = "LEFT";
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (cc.pickedObject != null && rightTile != null && (mirandoA.Equals("RIGHT") || mirandoA.Equals("LEFT")))
                {
                    MoveToPosition(rightTile.GetTilePosition());
                    mirandoA = "RIGHT";
                }
                else if (cc.pickedObject == null && rightTile != null) { 
                    MoveToPosition(rightTile.GetTilePosition());
                    mirandoA = "RIGHT";
                }
        }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (cc.pickedObject != null && forwardTile != null && (mirandoA.Equals("UP") || mirandoA.Equals("DOWN")))
                {
                    MoveToPosition(forwardTile.GetTilePosition());
                    mirandoA = "UP";
                }
                else if (cc.pickedObject == null && forwardTile != null) { 
                    MoveToPosition(forwardTile.GetTilePosition());
                    mirandoA = "UP";
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (cc.pickedObject != null && backwardTile != null && (mirandoA.Equals("UP") || mirandoA.Equals("DOWN")))
                {
                    MoveToPosition(backwardTile.GetTilePosition());
                    mirandoA = "DOWN";
                }
                else if (cc.pickedObject == null && backwardTile != null) { 
                    MoveToPosition(backwardTile.GetTilePosition());
                    mirandoA = "DOWN";
                }
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

}
