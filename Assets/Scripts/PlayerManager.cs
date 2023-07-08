using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [HideInInspector] public bool retir = false;
    public float moveSpeed;
    public GameObject balleActu;
    [HideInInspector] public float actualSpeed;
    public Camera cam;

    private float mousePosX;
    private float mousePosY;

    public bool isReady, isDead;

    private void Awake()
    {
        Instance = this;
        GameManager.OnGameStarted += OnGameStarted;
    }

    private void Start()
    {
        actualSpeed = moveSpeed;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void OnGameStarted()
    {
        isReady = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
    }
    private void Update()
    {
        if (isReady && !isDead)
        {
            //Initialisation des inputs
            mousePosX = Input.GetAxis("Mouse X");
            mousePosY = Input.GetAxis("Mouse Y");
            LimitMouseSpeed();

            balleActu.transform.Rotate(new Vector3(mousePosY, mousePosX, 0), Space.Self);
            balleActu.transform.eulerAngles = new Vector3(balleActu.transform.eulerAngles.x, balleActu.transform.eulerAngles.y, 0);
            //Debug.Log(new Vector2(mousePosX, mousePosY));

            //Déplacements
            balleActu.transform.Translate(Vector3.forward * actualSpeed * Time.deltaTime);
        }
    }

    private void LimitMouseSpeed()
    {
        if(!retir)
        { 
        if (mousePosX > 0.1f)
            mousePosX = 0.1f;
        if (mousePosX < -0.1f)
            mousePosX = -0.1f;

        if (mousePosY > 0.1f)
            mousePosY = 0.1f;
        if (mousePosY < -0.1f)
            mousePosY = -0.1f;
    

        }
    }
}
