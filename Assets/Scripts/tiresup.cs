using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiresup : MonoBehaviour
{
    private Vector3 rotationAvant;
    public GameObject currentBalle;
    [SerializeField] private GameObject balle;
    [SerializeField]private PlayerManager playerManager;
    [SerializeField] private Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cam.transform.localPosition = new Vector3(0, 0, 0);
            playerManager.actualSpeed = 0;
            rotationAvant = cam.transform.parent.rotation.eulerAngles;
        }
        if(Input.GetMouseButtonUp(0))
        {
            cam.transform.parent.GetComponent<avance>().enabled = true;
            currentBalle = Instantiate(balle,currentBalle.transform.position, cam.transform.parent.rotation);

            cam.transform.parent.eulerAngles = rotationAvant;
            cam.transform.SetParent(currentBalle.transform);
            playerManager.balleActu = currentBalle;
            playerManager.actualSpeed = playerManager.moveSpeed;
            cam.transform.localEulerAngles = Vector3.zero;
            cam.transform.localPosition = new Vector3(0, 2.35f, -10);

        }
    }
}
