using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerManager playerManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "sol" && collision.gameObject.tag != "cible")
        {
            playerManager.actualSpeed = 0;
            rb.AddForce(-transform.forward * 1000);
            rb.useGravity = true;

        }

    }
    
}
