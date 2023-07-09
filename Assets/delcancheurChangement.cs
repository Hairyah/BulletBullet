using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delcancheurChangement : MonoBehaviour
{
    [SerializeField] private cibleSuivante ciblesuivante;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("catouche1");
        ciblesuivante.changementCible(this.gameObject);
    }
}
