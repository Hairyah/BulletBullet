using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerManager playerManager;
    [SerializeField] private CinemachineVirtualCameraBase cinemachineCam;
    [SerializeField] private GameObject trails;
    [SerializeField] private GameObject AnimeSpeed;
    [SerializeField] private ToubilolTrail toubilolTrail;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        AnimeSpeed = GameObject.Find("AnimeSpeedLine");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "sol" && collision.gameObject.tag != "cible")
        {
            playerManager.actualSpeed = 0;
            rb.AddForce(-transform.forward * 1000);
            rb.useGravity = true;

            cinemachineCam.Priority = 0;
            Destroy(trails);
            Destroy(AnimeSpeed);
            Destroy(toubilolTrail);

            Cursor.lockState = CursorLockMode.Confined;
        }

    }
    
}
