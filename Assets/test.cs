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

    public GameObject trailDefaite;
    public GameObject SplashSang;
    public GameObject pointDeSpawnSang;

    private bool gameOverBool=false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        AnimeSpeed = GameObject.Find("AnimeSpeedLine");
        audioManager = FindObjectOfType<AudioManager>();
        nbTouche = 1;
        gameOverBool = false;
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
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                trailDefaite.SetActive(true);


                audioManager.Play("Fall"+nbTouche);
                nbTouche++;
                Cursor.lockState = CursorLockMode.Confined;

                //Appel le game manager pour lancer le game OVER
                if (!gameOverBool)
                {
                    gameOverBool = true;
                    GameManager.Instance.GameOver();
                }
            }
            else if(collision.gameObject.name == "cible")
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "cible")
        {
            var newSplashDeSang = Instantiate(SplashSang, pointDeSpawnSang.transform.position, transform.rotation);
            StartCoroutine(PauseSplash(newSplashDeSang));
        }
    }

    IEnumerator PauseSplash(GameObject spashAPauser)
    {
        yield return new WaitForSeconds(0.5f);

        spashAPauser.GetComponent<ParticleSystem>().Pause();
    }
}
