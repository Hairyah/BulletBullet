using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cibleSuivante : MonoBehaviour
{
    public Outlinez outline;
    public GameObject prochaineCible;
    void Start()
    {
        outline = gameObject.GetComponent<Outlinez>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            outline.enabled = false;
            prochaineCible.GetComponent<Outlinez>().enabled = true;

            prochaineCible.GetComponent<cibleSuivante>().enabled = true;
            this.enabled = false;

        }
    }
}
