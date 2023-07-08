using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;

    public Camera cam;

    public Rigidbody rb;

    private float mousePosX;
    private float mousePosY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Initialisation des inputs
        mousePosX = Input.GetAxis("Mouse X");
        mousePosY = Input.GetAxis("Mouse Y");

        LimitMouseSpeed();
   
        transform.Rotate(new Vector3(mousePosY, mousePosX, 0), Space.Self);
        Debug.Log(new Vector2(mousePosX, mousePosY));

        //Déplacements
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void LimitMouseSpeed()
    {
        if (mousePosX > 0.5)
            mousePosX = 1;
        if (mousePosX < -1)
            mousePosX = -1;

        if (mousePosY > 1)
            mousePosY = 1;
        if (mousePosY < -1)
            mousePosY = -1;
    }
}
