using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avance : MonoBehaviour
{
    public PlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerManager.actualSpeed * Time.deltaTime);
    }
}
