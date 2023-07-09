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

    public float limiteDeRotation=0.1f;

    private void Awake()
    {
        Instance = this;
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameEnded += OnGameEnded;
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

    void OnGameEnded()
    {
        isReady = false;
        isDead = true;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameEnded -= OnGameEnded;
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
        if (mousePosX > limiteDeRotation)
            mousePosX = limiteDeRotation;
        if (mousePosX < -limiteDeRotation)
            mousePosX = -limiteDeRotation;

        if (mousePosY > limiteDeRotation)
            mousePosY = limiteDeRotation;
        if (mousePosY < -limiteDeRotation)
            mousePosY = -limiteDeRotation;
    

        }
    }
}
