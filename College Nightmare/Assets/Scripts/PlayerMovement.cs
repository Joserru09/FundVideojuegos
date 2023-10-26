using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioPlayer;
    public AudioClip walkClip;


    private Vector3 PlayerMovementInput;
    public Transform orientation;
    private float xRot;

    private Rigidbody PlayerBody;
    public float Speed;
    public float Jumpforce;
    private bool estaensalto;
    private void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
        PlayerBody.freezeRotation = true;
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = walkClip;
        estaensalto = false;
    }
    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = orientation.TransformDirection(PlayerMovementInput);
        PlayerBody.velocity = new Vector3(MoveVector.x * Speed, PlayerBody.velocity.y, MoveVector.z * Speed);
        if (!estaensalto && PlayerMovementInput.magnitude != 0)
        {
            if (!audioPlayer.isPlaying) audioPlayer.Play();
        }
        else audioPlayer.Pause();
        if (!estaensalto && Input.GetKeyDown(KeyCode.Space))
        {
            estaensalto = true;
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor") estaensalto = false;
    }
}