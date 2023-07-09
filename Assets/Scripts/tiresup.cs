using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class tiresup : MonoBehaviour
{
    private Vector3 rotationAvant;
    public GameObject currentBalle;
    [SerializeField] private GameObject balle;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Camera cam;
    [SerializeField] private CinemachineVirtualCameraBase cinemachineCam;
    private AudioManager audioManager;

    public int maxShootNumber = 3;
    public Image bullet1;
    public Image bullet2;
    public Image bullet3;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (maxShootNumber > 0)
            {
                audioManager.Play("SlowMoStart");
                audioManager.Stop("Wind");
                cam.transform.localPosition = new Vector3(0, 0, 0);
                playerManager.actualSpeed = 3;
                //rotationAvant = cam.transform.parent.rotation.eulerAngles;
                playerManager.retir = true;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {

            if (maxShootNumber > 0)
            {

                maxShootNumber--;

                audioManager.Stop("SlowMoStart");
                audioManager.Play("SlowMoEnd");
                audioManager.Play("ShootSlowMo");
                audioManager.Play("Wind");
                playerManager.retir = false;
                //cam.transform.parent.GetComponent<avance>().enabled = true;
                //currentBalle = Instantiate(balle, currentBalle.transform.position, cam.transform.parent.rotation);
                var saveOldBalle = currentBalle;
                currentBalle = Instantiate(balle, saveOldBalle.transform.position, saveOldBalle.transform.rotation);

                saveOldBalle.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
                //var saveOldBalle = currentBalle;

                //currentBalle = Instantiate(balle, saveOldBalle.transform.position, saveOldBalle.transform.parent.rotation);

                //cam.transform.GetChild(0).gameObject.SetActive(true);
                //cam.transform.parent.eulerAngles = rotationAvant;
                //cam.transform.SetParent(currentBalle.transform);
                playerManager.balleActu = currentBalle;
                playerManager.actualSpeed = playerManager.moveSpeed;
                cam.transform.localEulerAngles = Vector3.zero;
                cam.transform.localPosition = new Vector3(0, 4.82f, -10);
            }
        }

        if(maxShootNumber == 2)
        {
            bullet1.color = new Color(bullet1.color.r, bullet1.color.g, bullet1.color.b, 0.2f);
        }
        else if(maxShootNumber == 1)
        {
            bullet2.color = new Color(bullet2.color.r, bullet2.color.g, bullet2.color.b, 0.2f);
        }
        else if(maxShootNumber <= 0)
        {
            bullet3.color = new Color(bullet3.color.r, bullet3.color.g, bullet3.color.b, 0.2f);
        }


    }
}