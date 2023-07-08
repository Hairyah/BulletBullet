using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class tiresup : MonoBehaviour
{

    private Vector3 rotationAvant;
    public GameObject currentBalle;
    [SerializeField] private GameObject balle;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Camera cam;
    [SerializeField] private CinemachineVirtualCameraBase cinemachineCam;
    private AudioManager audioManager;

    void Start()
    {
        audioManager= FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioManager.Play("SlowMoStart");
            audioManager.Stop("Wind");
            cam.transform.localPosition = new Vector3(0, 0, 0);
            playerManager.actualSpeed = 3;
            //rotationAvant = cam.transform.parent.rotation.eulerAngles;
            playerManager.retir = true;
            cam.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            audioManager.Stop("SlowMoStart");
            audioManager.Play("SlowMoEnd");
            audioManager.Play("Tir2");
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
}