using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerManager : MonoBehaviour
{
    public float moveSpeed;
    public float fireBulletForce;

    public Camera cam;
    public Rigidbody rb;

    private float mousePosX;
    private float mousePosY;

    bool isReady, isDead;

    private void Awake()
    {
        GameManager.OnGameStarted += OnGameStarted;
    }
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        
    }

    void OnGameStarted()
    {
        isReady = true;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.forward * fireBulletForce, ForceMode.Impulse);
        //rb.velocity = Vector3.forward * fireBulletForce;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
    }
    private void Update()
    {
        if(isReady && !isDead)
        {
            InputManager();
            LimitMouseSpeed();

            transform.Rotate(new Vector3(mousePosY, mousePosX, 0), Space.Self);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            Debug.Log(new Vector2(mousePosX, mousePosY));

            //Déplacements
            
        }
    }

    public void InputManager()
    {
        mousePosX = Input.GetAxis("Mouse X");
        mousePosY = Input.GetAxis("Mouse Y");
    }
    private void LimitMouseSpeed()
    {
        if (mousePosX > 1)
            mousePosX = 1;
        if (mousePosX < -1)
            mousePosX = -1;

        if (mousePosY > 1)
            mousePosY = 1;
        if (mousePosY < -1)
            mousePosY = -1;
    }
}
