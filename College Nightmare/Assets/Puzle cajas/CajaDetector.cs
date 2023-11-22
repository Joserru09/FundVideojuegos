using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaDetector : MonoBehaviour
{
    public enum CajaDetectorType
    {
        Left,
        Right,
        Forward,
        Backward,
        Floor
    }

    public CajaDetectorType detectorType;
    PlayerController player;

    void Start()
    {
        player = transform.parent.parent.GetComponent<PlayerController>();//we know the parent has this script
    }


    private void OnTriggerStay(Collider other)
    {
        Caja caja = other.GetComponent<Caja>();
        if (other.gameObject.CompareTag("Caja") && caja != null)
        {
            switch (detectorType)
            {
                case CajaDetectorType.Left:
                    player.SetLeftCaja(caja);
                    break;
                case CajaDetectorType.Right:
                    player.SetRightCaja(caja);
                    break;
                case CajaDetectorType.Forward:
                    player.SetForwardCaja(caja);
                    break;
                case CajaDetectorType.Backward:
                    player.SetBackwardCaja(caja);
                    break;
            }

        }
        else if (other.gameObject.CompareTag("CajaCogida") && caja != null)
        {
            switch (detectorType)
            {
                case CajaDetectorType.Left:
                    player.SetLeftCaja(null);
                    break;
                case CajaDetectorType.Right:
                    player.SetRightCaja(null);
                    break;
                case CajaDetectorType.Forward:
                    player.SetForwardCaja(null);
                    break;
                case CajaDetectorType.Backward:
                    player.SetBackwardCaja(null);
                    break;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        Caja caja = other.GetComponent<Caja>();
        if (caja != null)
        {
            switch (detectorType)
            {
                case CajaDetectorType.Left:
                    player.SetLeftCaja(null);
                    break;
                case CajaDetectorType.Right:
                    player.SetRightCaja(null);
                    break;
                case CajaDetectorType.Forward:
                    player.SetForwardCaja(null);
                    break;
                case CajaDetectorType.Backward:
                    player.SetBackwardCaja(null);
                    break;

            }

        }
    }

}
