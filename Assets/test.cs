using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool touche = false;
    public Rigidbody rb;
    public PlayerManager playerManager;
    [SerializeField] private CinemachineVirtualCameraBase cinemachineCam;
    [SerializeField] private GameObject trails;
    [SerializeField] private GameObject AnimeSpeed;
    [SerializeField] private ToubilolTrail toubilolTrail; 
    private AudioManager audioManager;
    private int nbTouche = 1;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        AnimeSpeed = GameObject.Find("AnimeSpeedLine");
        audioManager = FindObjectOfType<AudioManager>();
        nbTouche = 1;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!touche)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag != "cible" && collision.gameObject.tag != "Bullet")
            {
                playerManager.actualSpeed = 0;
                rb.AddForce(-transform.forward * 1000);
                rb.useGravity = true;

                cinemachineCam.Priority = 0;
                Destroy(trails);
                Destroy(AnimeSpeed);
                Destroy(toubilolTrail);


                audioManager.Play("Fall"+nbTouche);
                nbTouche++;
                Cursor.lockState = CursorLockMode.Confined;
            }else if(collision.gameObject.tag == "cible")
            {
                audioManager.Play("BloodSplash");
            }else if(collision.gameObject.tag == "sol")
            {
                audioManager.Play("Fall" + nbTouche);

                nbTouche++;
                if (nbTouche > 3)
                    nbTouche = 3;
            }
        }
    }
    
}
