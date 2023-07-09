using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cibleSuivante : MonoBehaviour
{
    public GameObject prochaineCible;
    public GameObject parent;
    public List<GameObject> liste;
    public GameObject enfant;

    void Start()
    {
        /*
        foreach (Transform Child in parent.transform)
        {
            liste.Add(Child.gameObject);
        }
        foreach (GameObject go in liste)
        {
            enfant = go.transform.GetChild(1).gameObject;
            enfant.AddComponent<Outlinez>();
            enfant.AddComponent<MeshCollider>();
            enfant.AddComponent<delcancheurChangement>();
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void changementCible(GameObject other)
    {
        /*
       
            other.GetComponent<Outlinez>().enabled = false;
            prochaineCible.GetComponent<Outlinez>().enabled = true;

            prochaineCible.GetComponent<cibleSuivante>().enabled = true;
            this.enabled = false;
        */
        Debug.Log(other);
    }
}
